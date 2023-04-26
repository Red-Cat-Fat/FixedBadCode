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
		private Game _game;
		public void Awake()
		{
			DontDestroyOnLoad(LoadCurtain);
			_game = new Game(LoadCurtain, this, GameSettings);

			DontDestroyOnLoad(this);
		}
	}
}
