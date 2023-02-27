using System.Linq;
using Archi.Service.Interface;
using BDD;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Windows;
using File = System.IO.File;

namespace Archi.Service
{
    public class DataBaseService : Service, IDataBaseService
    {
        private DataContainer container;
        
        protected override void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public string[] GetUserLevels(string id)
        {
            throw new System.NotImplementedException();
        }

        public string[] GetAllLevels()
        {
            throw new System.NotImplementedException();
        }

        public void CreateData(LevelData data, string id, string userName)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteData(LevelData data, string id, string userName)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateData()
        {
            throw new System.NotImplementedException();
        }

        public void GenerateDataLevel(LevelData data, string key = null)
        {
            var onDeviceData = container.allDatas.FirstOrDefault(i => i.id == data.id);
            var json = JsonUtility.ToJson(data);

            if (onDeviceData != default) UpdateDataLevel(json, data.id);
            else
            {
                string path = $"{Application.persistentDataPath}/SaveData/Level/{data.id}";
                File.WriteAllText(path,json);
            }
        }

        public void UpdateDataLevel(string jsonData, string dataId)
        {
            throw new System.NotImplementedException();
        }

        public void RemovedataLevel(string key)
        {
            throw new System.NotImplementedException();
        }

        public string GetUniqueIdentifier()
        {
            throw new System.NotImplementedException();
        }
    }
}