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

		public void Start()
		{
			var blueBalls = FindObjectsOfType<GreenTarget>();
			_direction = blueBalls[Random.Range(0, blueBalls.Length)].transform.position - transform.position;
			_direction = _direction.normalized;
		}

		private void Update()
		{
			MovePosition(_direction * _time.DeltaTime);
		}
	}
}