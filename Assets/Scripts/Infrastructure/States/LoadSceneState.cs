using Infrastructure.Service.LoadLevels;
using Infrastructure.Utility;
using UI.Common.StateViewers;

namespace Infrastructure.States
{
	public class LoadSceneState : IState
	{
		private readonly IStateViewer _loadCurtain;
		private readonly ILoadLevelService _loadLevelService;
		private const string _gamePlayScene = "GamePlay";

		public LoadSceneState(IStateViewer loadCurtain, ILoadLevelService loadLevelService)
		{
			_loadCurtain = loadCurtain;
			_loadLevelService = loadLevelService;
		}
		
		public void Enter()
		{
			_loadCurtain.Enable();
			_loadLevelService.Load(_gamePlayScene);
		}

		public void Exit()
		{
			_loadCurtain.Disable();
		}
	}
}