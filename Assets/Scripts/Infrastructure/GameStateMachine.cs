using Infrastructure.Service.LoadLevels;
using Infrastructure.States;
using Infrastructure.Utility;
using UI.Common.StateViewers;

namespace Infrastructure
{
	public class GameStateMachine
	{
		private IState _loadScene;
		private IState _gameBootstrap;
		
		public GameStateMachine(IStateViewer loadCurtain, ICoroutineRunner coroutineRunner)
		{
			_gameBootstrap = new GameBootstrapState();
			_loadScene = new LoadSceneState(loadCurtain, new UnitySceneLoadLevelService(coroutineRunner), _gameBootstrap);
		}

		public void Start()
		{
			_loadScene.Enter();
		}
	}
}