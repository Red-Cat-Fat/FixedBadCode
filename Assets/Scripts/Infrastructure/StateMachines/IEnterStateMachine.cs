using Infrastructure.States;

namespace Infrastructure.StateMachines
{
	public interface IEnterStateMachine
	{
		void Enter<TState>() where TState : IEnterState;
	}
}