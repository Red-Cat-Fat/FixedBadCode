using Infrastructure.Utility;
using UI.Common.StateViewers;
using UnityEngine;

namespace Infrastructure
{
	public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
	{
		public GroupCanvasStateViewer LoadCurtain;
		public void Awake()
		{
			DontDestroyOnLoad(LoadCurtain);
			var game = new Game(LoadCurtain, this);
			game.StateMachine.Start();
			
			DontDestroyOnLoad(this);
		}
	}
}
