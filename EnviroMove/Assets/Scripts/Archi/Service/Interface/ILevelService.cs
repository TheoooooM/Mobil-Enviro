using Levels;
using UnityEngine;

namespace Archi.Service.Interface
{
    public interface ILevelService : IService
    {
        Level LoadLevel(LevelData data, GameObject levelContainer= null); //Instantiate Level with Level script
        
        LevelData GetData(Level data); //Get Level From Data
    }
}