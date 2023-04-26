using Infrastructure.Service.LoadLevels;
using Infrastructure.StateMachines;
using UI.Common.StateViewers;

namespace Infrastructure.States
{
	public class LoadSceneEnterPayloadState : IEnterPayloadState<string>
	{
		private readonly IStateViewer _loadCurtain;
		private readonly ILoadLevelService _loadLevelService;
		private readonly IEnterStateMachine _enterStateMachine;

		public const string _gamePlayScene = "GamePlay";

		public LoadSceneEnterPayloadState(
			IStateViewer loadCurtain,
			ILoadLevelService loadLevelService,
			IEnterStateMachine enterStateMachine)
		{
			_loadCurtain = loadCurtain;
			_loadLevelService = loadLevelService;
			_enterStateMachine = enterStateMachine;
		}

		public void Enter(string payloadData)
		{
			_loadCurtain.Enable();
			_loadLevelService.Load(payloadData, Exit);
		}

		public void Exit()
		{
			_loadCurtain.Disable();
			_enterStateMachine.Enter<LevelInitializeState>();
		}
	}
}