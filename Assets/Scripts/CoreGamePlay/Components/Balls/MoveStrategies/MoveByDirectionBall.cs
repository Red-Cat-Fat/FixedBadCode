using CoreGamePlay.Components.Balls.MoveStrategies;
using CoreGamePlay.Components.Waiters;
using Infrastructure.Service.Times;
using UnityEngine;

namespace CoreGamePlay.Components.Balls
{
	public class MoveByDirectionBall : MovableBall, ITimeScaleWaiter
	{
		private Vector3 _direction;
	
		private ITimeService _time;

		public void Construct(ITimeService time)
		{
			_time = time;
		}

		public void Construct(Vector3 position)
		{
			_direction = position - transform.position;
			_direction = _direction.normalized;
		}

		private void Update()
		{
			MovePosition(_direction * _time.DeltaTime);
		}
	}
}