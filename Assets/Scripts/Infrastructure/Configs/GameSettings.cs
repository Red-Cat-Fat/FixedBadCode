using UnityEngine;

namespace Infrastructure.Configs
{
	[CreateAssetMenu(fileName = "GameSettings", menuName = "Configs/GameSettings", order = 0)]
	public class GameSettings : ScriptableObject
	{
		public GameObject UiPrefab;
		public GameObject TimeInputMobile;
		public GameObject TimeInputEditor;
		public LevelPreset[] LevelPresets;
	}
}