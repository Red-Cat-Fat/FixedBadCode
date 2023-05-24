using Infrastructure.Service;
using UnityEngine;

namespace CoreGamePlay.Factories.BallFactories
{
	public class SimpleBallFactory : BaseBallFactory
	{
		public SimpleBallFactory(BallType ballType, GameObject prefab, BallCounter counter,
			ServicesContainer servicesContainer)
			: base(ballType, prefab, counter,
				servicesContainer)
		{
		}

		protected override void DoSpawn(GameObject ball)
		{
			
		}
	}
}