using Infrastructure.Configs;
using Infrastructure.Service;
using Infrastructure.StateMachines;
using Infrastructure.Utility;
using UI.Common.StateViewers;

namespace Infrastructure
{
	public class Game
	{
		public GameStateMachine StateMachine;
		public readonly ServicesContainer ServicesContainer;
		public Game(GroupCanvasStateViewer loadCurtain, ICoroutineRunner coroutineRunner, GameSettings gameSettings)
		{
			StateMachine = new GameStateMachine(loadCurtain, coroutineRunner, gameSettings, ServicesContainer);
			StateMachine.CurrentState.Exit();
		}
	}
}