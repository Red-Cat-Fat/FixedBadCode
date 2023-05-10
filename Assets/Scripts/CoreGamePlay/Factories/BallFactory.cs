using CoreGamePlay.Components.Triggers;
using CoreGamePlay.Components.Waiters;
using Infrastructure.Service;
using Infrastructure.Service.Times;
using UnityEngine;

namespace CoreGamePlay.Factories
{
	public class BallFactory
	{
		private readonly BallType _ballType;
		private readonly GameObject _prefab;
		private readonly BallCounter _counter;
		private readonly ServicesContainer _servicesContainer;

		public BallFactory(
			BallType ballType,
			GameObject prefab,
			BallCounter counter,
			ServicesContainer servicesContainer)
		{
			_ballType = ballType;
			_prefab = prefab;
			_counter = counter;
			_servicesContainer = servicesContainer;
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
			
			var timeScaleWaiters = newGameObject.GetComponents<ITimeScaleWaiter>();
			foreach (var waiter in timeScaleWaiters)
				waiter.Construct(_servicesContainer.Get<ITimeScaleService>());
			
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