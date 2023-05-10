using System;
using Infrastructure.Service.Input;
using UnityEngine;

namespace Infrastructure.Service.Times
{
	public class UnityForceTimeChangerService : ITimeScaleService, IDisposable
	{
		private readonly IInputService _inputService;

		public float DeltaTime
			=> Time.deltaTime * TimeScale;

		public float TimeScale { get; private set; } = 1f;

		public UnityForceTimeChangerService(IInputService inputService)
		{
			_inputService = inputService;
			_inputService.ChangeTimeScaleEvent += OnTimeScaleChanged;
		}
		
		private void OnTimeScaleChanged(float delta)
		{
			var newTime = TimeScale + delta;
			TimeScale = Mathf.Clamp(newTime, 0.0f, 5);
		}
		
		public void Dispose()
		{
			_inputService.ChangeTimeScaleEvent -= OnTimeScaleChanged;
		}
	}
}