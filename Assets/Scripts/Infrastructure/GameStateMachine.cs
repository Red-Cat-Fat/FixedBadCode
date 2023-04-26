using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Configs;
using Infrastructure.Service.LoadLevels;
using Infrastructure.States;
using Infrastructure.Utility;
using UI.Common.StateViewers;
using UnityEngine;

namespace Infrastructure
{
	
	public class GameStateMachine
	{
		private readonly Dictionary<Type, IState> _gameStates;
		
		public GameStateMachine(
			IStateViewer loadCurtain, 
			ICoroutineRunner coroutineRunner,
			GameSettings gameSettings)
		{
			_gameStates = new Dictionary<Type, IState>
			{
				{
					typeof(LoadSceneState),
					new LoadSceneState(loadCurtain, new UnitySceneLoadLevelService(coroutineRunner), this)
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
			Enter<LoadSceneState, string>("GamePlay");
		}

		public void Enter<TState>() where TState : IState
		{
			_gameStates[typeof(TState)].Enter();
		}

		public void Enter<TState, TPayload>(TPayload payload)
			where TState : IStatePayload<TPayload>
		{
			var payloadState = (TState)_gameStates[typeof(TState)];
			if (payloadState == null)
			{
				Debug.LogError("Incorrect settings");
			}
			payloadState.Enter(payload);
		}
	}
}