using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

#if UNITY_STANDALONE && !UNITY_EDITOR
using JsonUtility = UnityEngine.JsonUtility;
#endif

public class SceneEditor : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;

    private List<List<List<GameObject>>> grid = new();
    private GameObject selectedPrefab;
    public int selectedPrefabIndex = 0;
    
    [SerializeField] private int sizeOfGridSpace = 1;

    private int[] screenSize;
    private Camera _camera;
    
    private GameObject parent;
    
    [SerializeField] private string path;
    [SerializeField] private TMP_InputField inputField;

    public bool isMoveCamera = true;
    
    
    
    private enum EditorMode
    {
        create,
        delete,
    }
    
    [SerializeField] private EditorMode Mode = EditorMode.create;

    private void Start()
    {
        if (inputField.text == "")
        {
            inputField.text = "newScene";
        }
        _camera = Camera.main;
        parent = new GameObject(name);
        path = "Assets/SavedPrefab/" + parent.name + ".prefab";
    }

    private void Update()
    {
        path = "Assets/SavedPrefab/" + parent.name + ".prefab";
        parent.name = inputField.text;
        screenSize = new int[2];
        screenSize[0] = Screen.width;
        screenSize[1] = Screen.height;
        selectedPrefab = prefabs[selectedPrefabIndex];
        if (Input.touchCount <= 0) return;
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) return;
        switch (Mode)
        {
            case EditorMode.create:
                Create();
                break;
            
            case EditorMode.delete:
                Delete();
                break;
        }
    }

    private void MoveCamera()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            _camera.transform.position += new Vector3(-touchDeltaPosition.x, 0, -touchDeltaPosition.y) * Time.deltaTime;
        }
    }

    private void Create()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began && isMoveCamera)
        {
            InstantiateNewBlock();
        }
        //else if the isMoveCamera is false
        else if (Input.GetTouch(0).phase == TouchPhase.Moved && !isMoveCamera)
        {
            InstantiateNewBlock();
        }
    }

    private void InstantiateNewBlock()
    {
        Vector3 position = Input.GetTouch(0).position;
        RaycastHit hitRay;
        Ray ray = _camera.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out hitRay))
        {
            position = hitRay.normal switch
            {
                Vector3 up when up == Vector3.up => hitRay.point + new Vector3(0, 0.5f, 0),
                Vector3 down when down == Vector3.down => hitRay.point + new Vector3(0, -0.5f, 0),
                Vector3 left when left == Vector3.left => hitRay.point + new Vector3(-0.5f, 0, 0),
                Vector3 right when right == Vector3.right => hitRay.point + new Vector3(0.5f, 0, 0),
                Vector3 forward when forward == Vector3.forward => hitRay.point + new Vector3(0, 0, 0.5f),
                Vector3 back when back == Vector3.back => hitRay.point + new Vector3(0, 0, -0.5f),
                _ => position
            };
        }
        else
        {
            position = _camera.ScreenToWorldPoint(new Vector3(position.x, position.y, 10));
        }

        position.x = Mathf.Round(position.x / sizeOfGridSpace) * sizeOfGridSpace;
        position.y = Mathf.Round(position.y / sizeOfGridSpace) * sizeOfGridSpace;
        position.z = Mathf.Round(position.z / sizeOfGridSpace) * sizeOfGridSpace;
        var newGo = Instantiate(selectedPrefab, position, Quaternion.identity);
        newGo.transform.parent = parent.transform;
        newGo.transform.localScale = new Vector3(1, 1, 1);
    }

    private void Delete()
    {
        Vector3 position = Input.GetTouch(0).position;
        RaycastHit hitRay;
        Ray ray = _camera.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out hitRay))
        {
            Destroy(hitRay.transform.gameObject);
        }
    }
    
    public void CleanScene()
    {
        parent = GameObject.Find(inputField.text);
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ChangePrefab(int index)
    {
        selectedPrefabIndex = index;
    }

    public void SwitchMode(int index)
    {
        Mode = (EditorMode) index;
    }
    
    public void ChangeMoveCamera()
    {
        isMoveCamera = !isMoveCamera;
    }

#if UNITY_EDITOR
    public void SaveScene()
    {
        if (AssetDatabase.LoadAssetAtPath<GameObject>(path) != null)
        {
            Debug.LogError("Name already exists");
            return;
        }
        
        if (parent.name == "")
        {
            Debug.LogError("Name is empty");
            return;
        }
        if (parent.transform.childCount == 0)
        {
            Debug.LogError("Parent is empty");
            return;
        }
        PrefabUtility.SaveAsPrefabAsset(parent, path);
    }
    
    public void LoadScene()
    {
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        prefab.name = inputField.text;
        Instantiate(prefab);
    }
#endif
#if UNITY_STANDALONE && !UNITY_EDITOR
    public void SaveScene()
    {
       //TODO

    }
    
    public void LoadScene()
    {
        //TODO
    }
#endif
    

}