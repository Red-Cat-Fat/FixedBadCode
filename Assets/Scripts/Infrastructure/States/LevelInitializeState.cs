using System.Collections.Generic;
using CoreGamePlay.Factories;
using Infrastructure.Configs;
using UnityEngine;

namespace Infrastructure.States
{
	public class LevelInitializeState : IState
	{
		private readonly GameObject _uiPrefab;
		private readonly LevelPreset _level;
		private readonly GameObject _spawner;

		private readonly List<BallFactory> _ballFactories = new List<BallFactory>();

		public LevelInitializeState(GameObject uiPrefab, LevelPreset level)
		{
			_uiPrefab = uiPrefab;
			_level = level;
		}
		
		public void Enter()
		{
			var ballCounter = new BallCounter();
			
			foreach (var spawnerPrefab in _level.BallSpawners)
			{
				var spawnerGameObject = new GameObject();
				var factory = new BallFactory(spawnerPrefab.Color, spawnerPrefab.BallPrefab, ballCounter);
				_ballFactories.Add(factory);
				var spawner = spawnerGameObject.AddComponent<BallSpawner>();
				spawner.Construct(factory, spawnerPrefab.Time);
				spawnerGameObject.name = string.Format(
					"Spawner: {0} in {1}sec",
					spawnerPrefab.Color,
					spawnerPrefab.Time);
			}
			
			Debug.LogFormat("Enter GameBootstrapState BallSpawner: {0}", _level.BallSpawners.Length);
			var ui = Object.Instantiate(_uiPrefab);
			var ballWaiterUi = ui.GetComponent<BallCounterUI>();
			ballWaiterUi.Construct(ballCounter);
		}

		public void Exit() { }
	}
}