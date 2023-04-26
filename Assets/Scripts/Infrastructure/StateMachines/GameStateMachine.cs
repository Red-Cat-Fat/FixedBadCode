using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Configs;
using Infrastructure.Service.LoadLevels;
using Infrastructure.States;
using Infrastructure.Utility;
using UI.Common.StateViewers;
using UnityEngine;

namespace Infrastructure.StateMachines
{
	
	public class GameStateMachine : IPayloadEnterStateMachine, IEnterStateMachine
	{
		private IState _currentState;
		private readonly Dictionary<Type, IState> _gameStates;
		
		public GameStateMachine(
			IStateViewer loadCurtain, 
			ICoroutineRunner coroutineRunner,
			GameSettings gameSettings)
		{
			_gameStates = new Dictionary<Type, IState>
			{
				{
					typeof(LoadSceneEnterPayloadState),
					new LoadSceneEnterPayloadState(loadCurtain, new UnitySceneLoadLevelService(coroutineRunner), this)
				},
				{
					typeof(LevelInitializeState),
					new LevelInitializeState(gameSettings.UiPrefab, gameSettings.LevelPresets.First())
				},
				{
					typeof(GamePlayState),
					new GamePlayState()
				},
			};
			Enter<LoadSceneEnterPayloadState, string>("GamePlay");
		}

		public void Enter<TState>() where TState : IEnterState
		{
			var enterState = (TState)_gameStates[typeof(TState)];
			if (enterState == null)
			{
				Debug.LogError("Incorrect settings");
				return;
			}
			enterState.Enter();
		}

		public void Enter<TState, TPayload>(TPayload payload)
			where TState : IEnterPayloadState<TPayload>
		{
			var payloadState = (TState)_gameStates[typeof(TState)];
			if (payloadState == null)
			{
				Debug.LogError("Incorrect settings");
				return;
			}
			payloadState.Enter(payload);
		}
	}
}