using Infrastructure.Service.Times;

namespace CoreGamePlay.Components.Waiters
{
	public interface ITimeScaleWaiter
	{
		void Construct(ITimeService timeService);
	}
}