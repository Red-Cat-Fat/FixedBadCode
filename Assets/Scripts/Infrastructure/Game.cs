using Infrastructure.Configs;
using Infrastructure.Utility;
using UI.Common.StateViewers;

namespace Infrastructure
{
	public class Game
	{
		public GameStateMachine StateMachine;

		public Game(GroupCanvasStateViewer loadCurtain, ICoroutineRunner coroutineRunner, LevelPreset levelPreset)
		{
			StateMachine = new GameStateMachine(loadCurtain, coroutineRunner, levelPreset);
		}
	}
}