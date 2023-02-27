using Google.MiniJSON;
using UnityEngine;

namespace Archi.Service.Interface
{
    public interface IDataBaseService : IService
    {
        string[] GetUserLevels(string id);
        string[] GetAllLevels();

        void CreateData(LevelData data, string id, string userName);
        void DeleteData(LevelData data, string id, string userName);
        void UpdateData();
        
        void GenerateDataLevel(LevelData data, string key = null);
        void UpdateDataLevel(string jsonData, string dataId);
        void RemovedataLevel(string key);
        
        string GetUniqueIdentifier();
    }
}