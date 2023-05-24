using CoreGamePlay.Components.Triggers;
using CoreGamePlay.Components.Waiters;
using Infrastructure.Service;
using Infrastructure.Service.Times;
using UnityEngine;

namespace CoreGamePlay.Factories.BallFactories
{
	public abstract class BaseBallFactory
	{
		protected readonly BallCounter _counter;
		
		private readonly BallType _ballType;
		private readonly GameObject _prefab;
		private readonly ServicesContainer _servicesContainer;

		protected BaseBallFactory(
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

		protected abstract void DoSpawn(GameObject ball);
		
		public void SpawnBall(Vector3 position)
		{
			var newGameObject = Object.Instantiate(
				_prefab,
				position,
				Quaternion.identity);

			DoSpawn(newGameObject);
			
			var factoryWaiters = newGameObject.GetComponents<IBallFactoryWaiter>();
			foreach (var waiter in factoryWaiters)
				waiter.Construct(this);
			
			var timeScaleWaiters = newGameObject.GetComponents<ITimeScaleWaiter>();
			foreach (var waiter in timeScaleWaiters)
				waiter.Construct(_servicesContainer.Get<ITimeService>());

			_counter.AddBall(_ballType, newGameObject);

			var destroyTrigger = newGameObject.AddComponent<OnDestroyTrigger>();
			destroyTrigger.DestroyEvent += OnBallDestroy;
		}
		
		private void OnBallDestroy(GameObject obj)
		{
			_counter.DelBall(_ballType, obj);
		}
	}
}