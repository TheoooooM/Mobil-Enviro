using Archi.Service.Interface;

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
    }
}