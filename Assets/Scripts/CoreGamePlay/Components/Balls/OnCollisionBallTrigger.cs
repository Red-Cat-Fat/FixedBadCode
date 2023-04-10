using CoreGamePlay.Components.Balls.CollisionStrategies;
using UnityEngine;

namespace CoreGamePlay.Components.Balls
{
	public class OnCollisionBallTrigger : MonoBehaviour
	{
		public BallType CollisionParent;
		private void OnCollisionEnter(Collision collision)
		{
			var ball = collision.gameObject.GetComponents<ICollisionStrategy>();
			if(ball.Length == 0)
				return;

			foreach (var bCollisionStrategy in ball)
			{
				bCollisionStrategy.OnCollision(CollisionParent);
			}
		}
	}
}