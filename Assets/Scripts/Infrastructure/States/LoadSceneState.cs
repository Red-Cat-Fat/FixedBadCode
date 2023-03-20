using Infrastructure.Service.LoadLevels;
using UI.Common.StateViewers;

namespace Infrastructure.States
{
	public class LoadSceneState : IState
	{
		private readonly IStateViewer _loadCurtain;
		private readonly ILoadLevelService _loadLevelService;
		private readonly IState _nextState;
		
		private const string _gamePlayScene = "GamePlay";

		public LoadSceneState(
			IStateViewer loadCurtain,
			ILoadLevelService loadLevelService,
			IState nextState)
		{
			_loadCurtain = loadCurtain;
			_loadLevelService = loadLevelService;
			_nextState = nextState;
		}
		
		public void Enter()
		{
			_loadCurtain.Enable();
			_loadLevelService.Load(_gamePlayScene, Exit);
		}

		public void Exit()
		{
			_loadCurtain.Disable();
			_nextState.Enter();
		}
	}
}