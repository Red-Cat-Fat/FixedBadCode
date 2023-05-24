using System.Collections.Generic;
using CoreGamePlay.Factories;
using CoreGamePlay.Factories.BallFactories;
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

		private readonly List<BaseBallFactory> _ballFactories = new List<BaseBallFactory>();

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

			Debug.LogFormat("Enter GameBootstrapState BallSpawner: {0}", _level.Spawners.Count);

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

			//_servicesContainer.Add<ITimeScaleService>(new FixedTimeService(10));
			_servicesContainer.Add<ITimeService>(new UnityForceTimeChangerService(_servicesContainer.Get<IInputService>()));
			
			foreach (var spawnerPrefab in _level.Spawners)
			{
				var spawnerGameObject = new GameObject();
				var factory = spawnerPrefab.MakeFactory(ballCounter, _servicesContainer);
				_ballFactories.Add(factory);
				var spawner = spawnerGameObject.AddComponent<BallSpawner>();
				spawner.Construct(_servicesContainer.Get<ITimeService>(), factory, spawnerPrefab.Time);
				spawnerGameObject.name = string.Format(
					"Spawner: {0} in {1}sec",
					spawnerPrefab.Color,
					spawnerPrefab.Time);
			}
			
			_enterStateMachine.Enter<GamePlayState>();
		}

		public void Exit()
		{
		}
	}
}