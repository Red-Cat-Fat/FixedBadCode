using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Configs;
using Infrastructure.Service.LoadLevels;
using Infrastructure.States;
using Infrastructure.Utility;
using UI.Common.StateViewers;

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
					typeof(LevelInitializeState),
					new LevelInitializeState(gameSettings.UiPrefab, gameSettings.LevelPresets.First())
				},
				{
					typeof(LoadSceneState),
					new LoadSceneState(loadCurtain, new UnitySceneLoadLevelService(coroutineRunner), this)
				},
				{
					typeof(GamePlayState),
					new GamePlayState()
				},
			};
			Enter<LoadSceneState>();
		}

		public void Enter<T>() where T : IState
		{
			_gameStates[typeof(T)].Enter();
		}
	}
}