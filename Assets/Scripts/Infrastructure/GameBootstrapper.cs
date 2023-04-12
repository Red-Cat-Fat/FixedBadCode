using Infrastructure.Configs;
using Infrastructure.Utility;
using UI.Common.StateViewers;
using UnityEngine;

namespace Infrastructure
{
	public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
	{
		public LevelPreset LevelPreset;
		public GroupCanvasStateViewer LoadCurtain;
		public void Awake()
		{
			DontDestroyOnLoad(LoadCurtain);
			var game = new Game(LoadCurtain, this, LevelPreset);
			game.StateMachine.Start();
			
			DontDestroyOnLoad(this);
		}
	}
}
