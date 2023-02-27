using Archi.Service.Interface;
using Google.MiniJSON;
using UnityEngine;

namespace Archi.Service
{
    public class GameService : Service, IGameService

    {
        protected override void Initialize()
        {
        }


        #region Interface
        public void CreateLoading()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLoading()
        {
            throw new System.NotImplementedException();
        }

        public void FinishLoading()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}