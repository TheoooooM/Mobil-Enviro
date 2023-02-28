using Archi.Service.Interface;
using Attributes;
using Levels;

namespace UI
{
    public class ToolUtilities : CanvasUtilities
    {
        [ServiceDependency] private IToolService m_Tool;

        public void SaveLevel()
        {
            m_Tool.SaveCurrentLevel();
        }
        
        private LevelData GetEditorData()
        {
            throw new System.NotImplementedException();
        }
    }
}
