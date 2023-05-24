using CoreGamePlay.Factories;
using CoreGamePlay.Factories.BallFactories;

namespace CoreGamePlay.Components.Waiters
{
	public interface IBallFactoryWaiter
	{
		void Construct(BaseBallFactory factory);
	}
}