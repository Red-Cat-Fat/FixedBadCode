using UI.Common.StateViewers;
using UnityEngine;

namespace Infrastructure
{
	public class GameBootstrapper : MonoBehaviour
	{
		public GameObject LoadCurtain;
		public void Awake()
		{
			Instantiate(LoadCurtain);
			DontDestroyOnLoad(LoadCurtain);
			var game = new Game(LoadCurtain.GetComponent<GroupCanvasStateViewer>());
			game.StateMachine.Start();
		}
	}
}
