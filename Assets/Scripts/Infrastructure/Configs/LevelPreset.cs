using System.Collections.Generic;
using CoreGamePlay.Factories.BallFactories.Data;
using SerializeReferenceEditor;
using UnityEngine;

namespace Infrastructure.Configs
{
	[CreateAssetMenu(menuName = "Configs/LevelPreset")]
	public class LevelPreset : ScriptableObject
	{
		[SR]
		[SerializeReference]
		public List<BaseBallSpawnerData> Spawners = new List<BaseBallSpawnerData>();
	}
}