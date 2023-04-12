using Infrastructure.Configs;
using Infrastructure.Utility;
using UI.Common.StateViewers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure
{
	public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
	{
		public GameSettings GameSettings;
		public GroupCanvasStateViewer LoadCurtain;
		public void Awake()
		{
			DontDestroyOnLoad(LoadCurtain);
			var game = new Game(LoadCurtain, this, GameSettings);
			game.StateMachine.Start();
			
			DontDestroyOnLoad(this);
		}
	}
}
