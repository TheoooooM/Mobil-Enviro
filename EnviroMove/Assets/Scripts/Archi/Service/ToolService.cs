using Archi.Service.Interface;
using Levels;

namespace Archi.Service
{
    public class ToolService : Service, IToolService
    {
        protected override void Initialize()
        { }

        public void ShowTool()
        {
            throw new System.NotImplementedException();
        }
        
        private LevelData GetEditorData()
        {
            throw new System.NotImplementedException();
        }

        public void SaveCurrentLevel()
        {
            throw new System.NotImplementedException();
        }
    }
}