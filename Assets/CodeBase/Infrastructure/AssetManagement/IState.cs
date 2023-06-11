namespace Infrastructure.AssetManagement
{
    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface IPayLoadState<TPayLoad> : IExitableState
    {
        void Enter(TPayLoad payLoad);
    }

    public interface IExitableState
    {
        void Exit();
    }
}