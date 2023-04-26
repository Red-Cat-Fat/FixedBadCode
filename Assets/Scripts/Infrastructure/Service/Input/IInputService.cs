using System;

namespace Infrastructure.Service.Input
{
	public interface IInputService : IService
	{
		event Action<float> ChangeTimeScaleEvent;
	}
}