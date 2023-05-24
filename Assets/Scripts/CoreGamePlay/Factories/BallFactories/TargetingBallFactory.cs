using CoreGamePlay.Components.Balls;
using Infrastructure.Service;
using UnityEngine;

namespace CoreGamePlay.Factories.BallFactories
{
	public class TargetingBallFactory : BaseBallFactory
	{
		private readonly BallType _targetType;
		public TargetingBallFactory(
			BallType targetType,
			BallType ballType,
			GameObject prefab,
			BallCounter counter,
			ServicesContainer servicesContainer)
			: base(
				ballType,
				prefab,
				counter,
				servicesContainer)
		{
			_targetType = targetType;
		}

		protected override void DoSpawn(GameObject ball)
		{
			var moveByDirection = ball.GetComponent<MoveByDirectionBall>();
			if (moveByDirection == null)
				moveByDirection = ball.AddComponent<MoveByDirectionBall>();
			
			var randomTarget = _counter.GetRandomBall(_targetType);
			
			if(randomTarget!=null)
				moveByDirection.Construct(randomTarget.transform.position);
			else
				moveByDirection.Construct(Random.onUnitSphere);
		}
	}
}