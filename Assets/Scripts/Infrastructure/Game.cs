using UI.Common.StateViewers;

namespace Infrastructure
{
	public class Game
	{
		public GameStateMachine StateMachine;

		public Game(GroupCanvasStateViewer loadCurtain)
		{
			StateMachine = new GameStateMachine(loadCurtain);
		}
	}
}