using System.Collections.Generic;
using CoreGamePlay.Factories;
using Infrastructure.Configs;
using Infrastructure.Service;
using Infrastructure.Service.Input;
using Infrastructure.Service.Times;
using Infrastructure.StateMachines;
using UI.Common.GamePlayHUD;
using UnityEngine;

namespace Infrastructure.States
{
	public class LevelInitializeState : IEnterState
	{
		private readonly GameSettings _gameSettings;
		private readonly LevelPreset _level;
		private readonly IEnterStateMachine _enterStateMachine;
		private readonly ServicesContainer _servicesContainer;
		private readonly GameObject _spawner;

		private readonly List<BallFactory> _ballFactories = new List<BallFactory>();

		public LevelInitializeState(
			GameSettings gameSettings,
			LevelPreset level,
			IEnterStateMachine enterStateMachine,
			ServicesContainer servicesContainer)
		{
			_gameSettings = gameSettings;
			_level = level;
			_enterStateMachine = enterStateMachine;
			_servicesContainer = servicesContainer;
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

			var ui = Object.Instantiate(_gameSettings.UiPrefab);
			var ballWaiterUi = ui.GetComponent<BallCounterUI>();
			ballWaiterUi.Construct(ballCounter);

			GameObject controlPrefab;
			if (Application.isEditor)
				controlPrefab = Object.Instantiate(_gameSettings.TimeInputEditor);
			else
				controlPrefab = Object.Instantiate(_gameSettings.TimeInputMobile, ui.transform);
			
			var inputService = controlPrefab.GetComponent<IInputService>();
			_servicesContainer.Add(inputService);
			var timeController = new UnityForceTimeChangerService(inputService);
			_servicesContainer.Add<ITimeScaleService>(timeController);
			
			_enterStateMachine.Enter<GamePlayState>();
		}

		public void Exit()
		{
		}
	}
}