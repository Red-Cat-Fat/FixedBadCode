using Infrastructure.Service;

namespace CoreGamePlay.Factories.BallFactories.Data
{
	
	public class SimpleBallSpawnerData : BaseBallSpawnerData
	{
		public override BaseBallFactory MakeFactory(BallCounter counter, ServicesContainer servicesContainer)
			=> new SimpleBallFactory(
				Color,
				BallPrefab,
				counter,
				servicesContainer);
	}
}