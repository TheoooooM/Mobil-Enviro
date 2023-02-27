namespace Archi.Service.Interface
{
    public interface IGameService : IService
    {
        void CreateLoading();
        void UpdateLoading();
        void FinishLoading();
    }
}