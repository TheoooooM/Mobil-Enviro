using Archi.Service.Interface;
using Attributes;
using Google.MiniJSON;
using UnityEngine;

namespace Archi.Service
{
    public class GameService : Service, IGameService
    {
        [DependeOnService] private IInterfaceService m_Interface;
        [DependeOnService] private ITickService m_Tick;
        
        
        protected override void Initialize()
        {
            m_Interface.DrawCanvas(Enums.MajorCanvas.menu);
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