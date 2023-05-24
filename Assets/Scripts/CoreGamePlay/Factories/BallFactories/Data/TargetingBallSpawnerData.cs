using System;
using Infrastructure.Service;

namespace CoreGamePlay.Factories.BallFactories.Data
{
	[Serializable]
	public class TargetingBaseBallSpawnerData : BaseBallSpawnerData
	{
		public BallType TargetType;
		public override BaseBallFactory MakeFactory(BallCounter counter, ServicesContainer servicesContainer)
			=> new TargetingBallFactory(TargetType, Color, BallPrefab, counter, servicesContainer);
	}
}