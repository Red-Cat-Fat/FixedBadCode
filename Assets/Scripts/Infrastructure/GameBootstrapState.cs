using Infrastructure.States;
using UnityEngine;

namespace Infrastructure
{
	public class GameBootstrapState : IState
	{
		public void Enter()
		{
			Debug.LogWarning("On GameBootstrapState");
		}

		public void Exit()
		{
			
		}
	}
}