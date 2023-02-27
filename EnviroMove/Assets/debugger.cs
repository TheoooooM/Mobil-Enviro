using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class debugger : MonoBehaviour
{
    public AssetReference refe;
    void Start()
    {  
        Debug.Log($"BuildPath: {Addressables.BuildPath}");
        Debug.Log($"LibraryPath: {Addressables.LibraryPath}");
        Debug.Log($"RuntimePath: {Addressables.RuntimePath}");
        Debug.Log($"PlayerBuildDataPath: {Addressables.PlayerBuildDataPath}");
    }
}
