using Infrastructure.Service;
using Infrastructure.Service.Times;
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
			var timeService = _servicesContainer.Get<ITimeScaleService>();
			Debug.Log(timeService.DeltaTime);
		}
		
		public void Exit()
		{
			Debug.Log("I'm not in gameplay");
		}
	}
}