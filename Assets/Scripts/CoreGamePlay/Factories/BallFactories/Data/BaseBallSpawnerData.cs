using System;
using Infrastructure.Service;
using UnityEngine;

namespace CoreGamePlay.Factories.BallFactories.Data
{
	[Serializable]
	public abstract class BaseBallSpawnerData
	{
		public BallType Color;
		public GameObject BallPrefab;
		public float Time;

		public abstract BaseBallFactory MakeFactory(BallCounter counter, ServicesContainer servicesContainer);
	}
}