using CoreGamePlay.Components.Triggers;
using CoreGamePlay.Components.Waiters;
using UnityEngine;

namespace CoreGamePlay.Factories
{
	public class BallFactory
	{
		private readonly BallType _ballType;
		private readonly GameObject _prefab;
		private readonly BallCounter _counter;

		public BallFactory(BallType ballType, GameObject prefab, BallCounter counter)
		{
			_ballType = ballType;
			_prefab = prefab;
			_counter = counter;
		}

		public void SpawnBall(Vector3 position)
		{
			var newGameObject = Object.Instantiate(
				_prefab,
				position,
				Quaternion.identity);

			var factoryWaiters = newGameObject.GetComponents<IBallFactoryWaiter>();
			foreach (var waiter in factoryWaiters)
				waiter.Construct(this);
			
			_counter.AddBall(_ballType);

			var destroyTrigger = newGameObject.AddComponent<OnDestroyTrigger>();
			destroyTrigger.DestroyEvent += OnBallDestroy;
		}
		
		private void OnBallDestroy(GameObject obj)
		{
			_counter.DelBall(_ballType);
		}
	}
}