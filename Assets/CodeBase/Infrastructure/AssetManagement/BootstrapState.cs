namespace Infrastructure.AssetManagement
{
    public class BootstrapState : IState
    {
        private const string Initiail = "Initiail";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            //  var registerServices = RegisterServices();
            _sceneLoader.Load(Initiail, EnterLoadLevel);
        }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadLevelState, string>("New Sorpigal");

        public void Exit()
        {
        }
    }
}