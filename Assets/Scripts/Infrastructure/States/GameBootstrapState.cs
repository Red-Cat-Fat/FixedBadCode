using UnityEngine;

namespace Infrastructure.States
{
	public class GameBootstrapState : IState
	{
		public void Enter()
		{
			var ballCounter = new BallCounter();
			var spawners = Object.FindObjectsOfType<BallSpawner>(); //не делайте так - это плохо
			foreach (var ballSpawner in spawners) 
				ballSpawner.Constuct(ballCounter);
			Debug.LogFormat("Enter GameBootstrapState BallSpawner: {0}", spawners.Length);
			
			var ui = Object.FindObjectsOfType<BallCounterUI>(); //не делайте так - это плохо
			foreach (var ballWaiters in ui) 
				ballWaiters.Constuct(ballCounter);
			Debug.LogFormat("Enter GameBootstrapState BallCounterUI: {0}", ui.Length);
		}

		public void Exit() { }
	}
}