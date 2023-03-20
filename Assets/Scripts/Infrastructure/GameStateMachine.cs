using Infrastructure.States;
using UI.Common.StateViewers;

namespace Infrastructure
{
	public class GameStateMachine
	{
		private IState _loadScene;
		public GameStateMachine(GroupCanvasStateViewer groupCanvasStateViewer)
		{
			_loadScene = new LoadSceneState(groupCanvasStateViewer);
		}

		public void Start()
		{
			_loadScene.Enter();
		}
	}
}