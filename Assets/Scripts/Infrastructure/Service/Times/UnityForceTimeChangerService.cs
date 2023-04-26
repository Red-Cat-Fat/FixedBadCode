using System;
using Infrastructure.Service.Input;
using UnityEngine;

namespace Infrastructure.Service.Times
{
	public class UnityForceTimeChangerService : ITimeScaleService, IDisposable
	{
		private readonly IInputService _inputService;

		public UnityForceTimeChangerService(IInputService inputService)
		{
			_inputService = inputService;
			_inputService.ChangeTimeScaleEvent += OnTimeScaleChanged;
		}
		
		private void OnTimeScaleChanged(float delta)
		{
			var newTime = Time.timeScale + delta;
			Time.timeScale = Mathf.Clamp(newTime, 0.1f, 5);
		}
		
		public void Dispose()
		{
			_inputService.ChangeTimeScaleEvent -= OnTimeScaleChanged;
		}
	}
}