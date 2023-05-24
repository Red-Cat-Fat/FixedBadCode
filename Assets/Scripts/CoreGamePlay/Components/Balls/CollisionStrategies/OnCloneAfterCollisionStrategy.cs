using CoreGamePlay.Components.Waiters;
using CoreGamePlay.Factories;
using CoreGamePlay.Factories.BallFactories;
using UnityEngine;

namespace CoreGamePlay.Components.Balls.CollisionStrategies
{
	public class OnCloneAfterCollisionStrategy : BaseCollisionStrategy, IBallFactoryWaiter
	{
		private BaseBallFactory _factory;

		public void Construct(BaseBallFactory factory)
		{
			_factory = factory;
		}
		
		protected override void DoCollision()
			=> _factory.SpawnBall(transform.position + Random.insideUnitSphere.normalized * 2);
	}
}