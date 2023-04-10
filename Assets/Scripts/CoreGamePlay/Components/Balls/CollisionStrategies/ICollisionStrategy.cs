namespace CoreGamePlay.Components.Balls.CollisionStrategies
{
	public interface ICollisionStrategy
	{
		void OnCollision(BallType collision);
	}
}