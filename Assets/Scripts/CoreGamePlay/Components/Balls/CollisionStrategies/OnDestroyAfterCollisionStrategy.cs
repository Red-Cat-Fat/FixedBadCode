using CoreGamePlay.Components.Waiters;

namespace CoreGamePlay.Components.Balls.CollisionStrategies
{
	public class OnDestroyAfterCollisionStrategy : BaseCollisionStrategy, IBallCounterWaiter
	{
		private BallCounter _counter;
		
		public void Constuct(BallCounter counter)
		{
			_counter = counter;
		}

		protected override void DoCollision()
		{
			Destroy(this.gameObject);
			_counter.DelBall(BallType.Green);
		}
	}
}