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
			_loadLevelService.Load(payloadData, ()=>_enterStateMachine.Enter<LevelInitializeState>());
		}

		public void Exit()
		{
			_loadCurtain.Disable();
		}
	}
}