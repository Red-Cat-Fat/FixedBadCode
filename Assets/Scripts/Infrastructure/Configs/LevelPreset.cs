using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure.Configs
{
	[CreateAssetMenu(menuName = "Configs/LevelPreset")]
	public class LevelPreset : ScriptableObject
	{
		[Serializable]
		public struct BallColorSpawnerPrefabs
		{
			public BallType Color;
			public GameObject BallPrefab;
			public float Time;
		}

		public BallColorSpawnerPrefabs[] BallSpawners;
		
	}
}