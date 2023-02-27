using Archi.Service.Interface;
using UnityEngine;

namespace Archi.Service
{
    public class InterfaceService : Service, IInterfaceService
    {
        protected override void Initialize()
        { }

        public void DrawCanvas(Enums.MajorCanvas canvas)
        {
            swi
        }

        public void GeneratePopUp(string title, string message, Sprite icon = null)
        {
            throw new System.NotImplementedException();
        }

        public void GenerateLoadingScreen(string loadingName, float loadingMaxValue)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLoadingScreen(float progressValue)
        {
            throw new System.NotImplementedException();
        }

        public void HideLoadingScreen()
        {
            throw new System.NotImplementedException();
        }
    }
}