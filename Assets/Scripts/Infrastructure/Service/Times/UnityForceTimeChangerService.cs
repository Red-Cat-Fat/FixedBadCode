using System;
using Infrastructure.Service.Input;
using UnityEngine;

namespace Infrastructure.Service.Times
{
	public class UnityForceTimeChangerService : ITimeService, IDisposable
	{
		private readonly IInputService _inputService;

		public float DeltaTime
			=> Time.deltaTime * _timeScale;

		private float _timeScale  = 1f;

		public UnityForceTimeChangerService(IInputService inputService)
		{
			_inputService = inputService;
			_inputService.ChangeTimeScaleEvent += OnTimeScaleChanged;
		}
		
		private void OnTimeScaleChanged(float delta)
		{
			var newTime = _timeScale + delta;
			_timeScale = Mathf.Clamp(newTime, 0.0f, 5);
		}
		
		public void Dispose()
		{
			_inputService.ChangeTimeScaleEvent -= OnTimeScaleChanged;
		}
	}
}