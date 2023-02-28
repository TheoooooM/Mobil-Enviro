using Interfaces;
using UnityEngine;

namespace Levels
{
    public class LevelData : MonoBehaviour
    {
        public string id;
    
        private Vector2Int size;
        private int[,,] blockGrid; //Grid by index of blocksUse
        private string[] blocksUse;

        public LevelData(Vector2Int levelSize, IBoardable[,,] levelBlockGrid, GameObject[] levelBlocksUse)
        {
            throw new System.NotImplementedException();
        
        }
    
    }
}