namespace CoreGamePlay.Components.Balls.CollisionStrategies
{
	public class OnDestroyAfterCollisionStrategy : BaseCollisionStrategy
	{
		protected override void DoCollision()
		{
			Destroy(gameObject);
		}
	}
}