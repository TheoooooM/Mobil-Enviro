using System;
using System.Linq;
using Archi.Service.Interface;
using Interfaces;
using Levels;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

#if UNITY_STANDALONE && !UNITY_EDITOR
using JsonUtility = UnityEngine.JsonUtility;
#endif

public class SceneEditor : MonoBehaviour
{
    public IDataBaseService m_Data;
    
    [SerializeField] private GameObject[] prefabs;

    private GameObject selectedPrefab;
    public int selectedPrefabIndex;

    [SerializeField] private int sizeOfGridSpace = 1;

    private int[] screenSize;
    private Camera _camera;

    private GameObject parent;

    [SerializeField] private string path;
    [SerializeField] private TMP_InputField inputField;

    public bool isMoveCamera = true;


    //LevelData
    private Vector3Int size;
    public int[,,] blockGrid;
    public int[] blocksUsed;


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
        Debug.Log("TryCast");
        if (Physics.Raycast(ray, out hitRay))
        {
            Debug.Log(hitRay.point);
            position = hitRay.normal switch
            {
                var up when up == Vector3.up => hitRay.point + new Vector3(0, 0.5f, 0),
                var down when down == Vector3.down => hitRay.point + new Vector3(0, -0.5f, 0),
                var left when left == Vector3.left => hitRay.point + new Vector3(-0.5f, 0, 0),
                var right when right == Vector3.right => hitRay.point + new Vector3(0.5f, 0, 0),
                var forward when forward == Vector3.forward => hitRay.point + new Vector3(0, 0, 0.5f),
                var back when back == Vector3.back => hitRay.point + new Vector3(0, 0, -0.5f),
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

    private void UpdateGrid()
    {
        foreach (Transform child in parent.transform)
        {
            var position = child.position;
            size = new Vector3Int(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y),
                Mathf.RoundToInt(position.z));
            blockGrid = new int[size.x,size.y,size.z];
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    for (int z = 0; z < size.z; z++)
                    {
                        blockGrid[x, y, z] = -1;
                    }
                }
            }
            foreach (Transform block in parent.transform)
            {
                var blockPosition = block.position;
                blockGrid[Mathf.RoundToInt(blockPosition.x), Mathf.RoundToInt(blockPosition.y),
                    Mathf.RoundToInt(blockPosition.z)] = Array.IndexOf(prefabs, block.gameObject);
            }
        }
    }

    public void SaveData()
    {
       m_Data.GenerateDataLevel(data);
    }
    
    public void LoadData(LevelData dataToLoad)
    {
        
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
        Mode = (EditorMode)index;
    }

    public void ChangeMoveCamera()
    {
        isMoveCamera = !isMoveCamera;
    }
}