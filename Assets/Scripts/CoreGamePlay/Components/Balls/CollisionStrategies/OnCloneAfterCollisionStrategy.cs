using CoreGamePlay.Components.Waiters;
using CoreGamePlay.Factories;
using UnityEngine;

namespace CoreGamePlay.Components.Balls.CollisionStrategies
{
	public class OnCloneAfterCollisionStrategy : BaseCollisionStrategy, IBallFactoryWaiter
	{
		private BallFactory _factory;

		public void Construct(BallFactory factory)
		{
			_factory = factory;
		}
		
		protected override void DoCollision()
			=> _factory.SpawnBall(transform.position + Random.insideUnitSphere.normalized * 2);
	}
}