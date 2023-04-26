using System;

namespace Infrastructure.Service.Input
{
	public interface IInputService : IService
	{
		event Action<float> ChangeTimeScaleEvent;
		event Action<float> PauseEvent;
	}
}