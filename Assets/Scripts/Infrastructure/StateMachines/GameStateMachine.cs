using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Configs;
using Infrastructure.Service;
using Infrastructure.States;
using Infrastructure.Utility;
using UI.Common.StateViewers;
using UnityEngine;

namespace Infrastructure.StateMachines
{
	public class GameStateMachine : IPayloadEnterStateMachine, IEnterStateMachine
	{
		private readonly Dictionary<Type, IState> _gameStates;

		private IState _currentState;

		public IState CurrentState
			=> _currentState;
		
		public GameStateMachine(
			IStateViewer loadCurtain,
			ICoroutineRunner coroutineRunner,
			GameSettings gameSettings,
			ServicesContainer servicesContainer)
		{
			_gameStates = new Dictionary<Type, IState>
			{
				{
					typeof(LoadSceneEnterPayloadState),
					new LoadSceneEnterPayloadState(loadCurtain, coroutineRunner, this, servicesContainer)
				},
				{
					typeof(LevelInitializeState),
					new LevelInitializeState(gameSettings, gameSettings.LevelPresets.First(), this, servicesContainer)
				},
				{
					typeof(GamePlayState), new GamePlayState(servicesContainer)
				},
			};
			_currentState = Enter<LoadSceneEnterPayloadState, string>("GamePlay");
		}

		public IState Enter<TState>()
			where TState : IEnterState
		{
			var enterState = (IEnterState) _gameStates[typeof(TState)];
			if (enterState == null)
			{
				Debug.LogError("Incorrect settings");
				return null;
			}
			_currentState?.Exit();
			enterState.Enter();
			_currentState = enterState;
			return enterState;
		}

		public IState Enter<TState, TPayload>(TPayload payload)
			where TState : IEnterPayloadState<TPayload>
		{
			var payloadState = (TState) _gameStates[typeof(TState)];
			if (payloadState == null)
			{
				Debug.LogError("Incorrect settings");
				return null;
			}
			_currentState?.Exit();
			payloadState.Enter(payload);
			_currentState = payloadState;
			return payloadState;
		}
	}
}