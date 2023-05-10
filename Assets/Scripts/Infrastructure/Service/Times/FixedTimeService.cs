using UnityEngine;

namespace Infrastructure.Service.Times
{
	public class FixedTimeService : ITimeService
	{
		public float DeltaTime
			=> Time.deltaTime * TimeScale;

		private float TimeScale { get; }

		public FixedTimeService(float timeScale)
		{
			TimeScale = timeScale;
		}
	}
}