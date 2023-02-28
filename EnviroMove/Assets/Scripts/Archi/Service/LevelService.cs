using Archi.Service.Interface;
using Levels;
using Unity.VisualScripting;
using UnityEngine;

namespace Archi.Service
{
    public class LevelService : Service, ILevelService
    {
        protected override void Initialize()
        { }

        public Level LoadLevel(LevelData data, GameObject levelContainer= null)
        {
            Level level;
            if (levelContainer) level = levelContainer.AddComponent<Level>();
            else
            {
                var go = Object.Instantiate(new());
                level = go.AddComponent<Level>();
            }
            
            level.levelData = data;
            level.GenerateLevel();
            return level;
        }

        public LevelData GetData(Level level)
        {
            return level.levelData;
        }
    }
}