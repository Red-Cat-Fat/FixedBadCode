using UnityEngine;

namespace Infrastructure.States
{
	public class GamePlayState : IEnterState
	{
		public void Enter()
		{
			Debug.Log("I'm in gameplay");
		}
		
		public void Exit()
		{
			Debug.Log("I'm not in gameplay");
		}
	}
}