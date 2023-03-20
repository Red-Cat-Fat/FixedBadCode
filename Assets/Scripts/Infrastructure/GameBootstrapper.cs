using UnityEngine;

namespace Infrastructure
{
	public class GameBootstrapper : MonoBehaviour
	{
		public void Awake()
		{
			var game = new Game();
		}
	}
}
