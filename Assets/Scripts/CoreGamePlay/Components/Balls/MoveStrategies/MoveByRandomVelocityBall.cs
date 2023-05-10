using CoreGamePlay.Components.Balls.MoveStrategies;
using CoreGamePlay.Components.Waiters;
using Infrastructure.Service;
using Infrastructure.Service.Times;
using UnityEngine;

namespace CoreGamePlay.Components.Balls
{
	public class MoveByRandomVelocityBall : MovableBall, ITimeScaleWaiter
	{
		public float RandomCooldown = 1f;
		public float Velocity = 5;

		private ITimeScaleService _timeScaleService;
		private ServicesContainer _serviceContainer;
		private float _time = 0;
		private Vector3 _currentDirection;
		
		public void Construct(ITimeScaleService timeScaleService)
			=> _timeScaleService = timeScaleService;

		private void Update()
		{
			_time -= _timeScaleService.DeltaTime;
			if (_time < 0)
			{
				_currentDirection = Random.insideUnitSphere * Velocity;
				_time = RandomCooldown;
			}
			
			MovePosition(_currentDirection * _timeScaleService.DeltaTime);
		}
	}
}