using Infrastructure.Utility;
using UI.Common.StateViewers;

namespace Infrastructure
{
	public class Game
	{
		public GameStateMachine StateMachine;

		public Game(GroupCanvasStateViewer loadCurtain, ICoroutineRunner coroutineRunner)
		{
			StateMachine = new GameStateMachine(loadCurtain, coroutineRunner);
		}
	}
}