using System.Collections;
using Infrastructure.Utility;
using UnityEngine.SceneManagement;

namespace Infrastructure.Service.LoadLevels
{
	public class UnitySceneLoadLevelService : ILoadLevelService
	{
		private readonly ICoroutineRunner _coroutineRunner;

		public UnitySceneLoadLevelService(ICoroutineRunner coroutineRunner)
		{
			_coroutineRunner = coroutineRunner;
		}
		
		public void Load(string name)
			=> _coroutineRunner.StartCoroutine(LoadScene(name));

		private IEnumerator LoadScene(string name)
		{
			if (SceneManager.GetActiveScene().name == name)
				yield break;
			
			var waitLoadScene = SceneManager.LoadSceneAsync(name);

			while (!waitLoadScene.isDone)
			{
				yield return null;
			}
		}
	}
}