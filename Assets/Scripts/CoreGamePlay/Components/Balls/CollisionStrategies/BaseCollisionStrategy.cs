using System.Linq;
using UnityEngine;

namespace CoreGamePlay.Components.Balls.CollisionStrategies
{
	public abstract class BaseCollisionStrategy : MonoBehaviour, ICollisionStrategy
	{
		[SerializeField]
		private BallType[] _collisionDetected;

		private bool IsAffected(BallType collisionType)
			=> _collisionDetected.Contains(collisionType);

		public void OnCollision(BallType collision)
		{
			if(IsAffected(collision))
				DoCollision();
		}

		protected abstract void DoCollision();
	}
}