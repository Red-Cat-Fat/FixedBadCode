using UnityEngine.SceneManagement;

namespace Infrastructure.States
{
	public class LoadSceneState : IState
	{
		private const string _gamePlayScene = "GamePlay";

		public void Enter()
		{
			SceneManager.LoadScene(_gamePlayScene);
		}

		public void Exit()
		{
			
		}
	}
}