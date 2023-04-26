using System.ComponentModel.Design;
using Infrastructure.Service;
using Infrastructure.Service.LoadLevels;
using Infrastructure.StateMachines;
using Infrastructure.Utility;
using UI.Common.StateViewers;

namespace Infrastructure.States
{
	public class LoadSceneEnterPayloadState : IEnterPayloadState<string>
	{
		private readonly IStateViewer _loadCurtain;
		private readonly UnitySceneLoadLevelService _loadLevelService;
		private readonly IEnterStateMachine _enterStateMachine;

		public LoadSceneEnterPayloadState(
			IStateViewer loadCurtain,
			ICoroutineRunner coroutineRunner,
			IEnterStateMachine enterStateMachine,
			ServicesContainer servicesContainer)
		{
			_loadCurtain = loadCurtain;
			_loadLevelService = new UnitySceneLoadLevelService(coroutineRunner);
			servicesContainer.Add<ILoadLevelService>(_loadLevelService);
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