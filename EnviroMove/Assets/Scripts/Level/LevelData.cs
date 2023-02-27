using System.Collections;
using System.Collections.Generic;
using Google.MiniJSON;
using Interfaces;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    private Vector2Int size;
    private int[,,] blockGrid; //Grid by index of blocksUse
    private string[] blocksUse;

    public LevelData(Vector2Int levelSize, IBoardable[,,] levelBlockGrid, GameObject[] levelBlocksUse)
    {
        throw new System.NotImplementedException();
        
    }
    
}
