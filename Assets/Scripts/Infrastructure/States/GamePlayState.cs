using Infrastructure.Service;
using UnityEngine;

namespace Infrastructure.States
{
	public class GamePlayState : IEnterState
	{
		private readonly ServicesContainer _servicesContainer;
		public GamePlayState(ServicesContainer servicesContainer)
		{
			_servicesContainer = servicesContainer;
		}
		
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