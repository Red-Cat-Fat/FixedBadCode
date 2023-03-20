using UnityEngine.SceneManagement;

namespace Infrastructure.Service.LoadLevels
{
	public class UnitySceneLoadLevelService : ILoadLevelService
	{
		public void Load(string name)
		{
			if(SceneManager.GetActiveScene().name != name)
				SceneManager.LoadScene(name);
		}
	}
}