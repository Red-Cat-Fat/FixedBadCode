namespace Infrastructure.States
{
	public interface IState
	{
	}

	public interface IEnterState : IState
	{
		void Enter();
	}

	public interface IEnterPayloadState<T> : IState
	{
		void Enter(T payloadData);
	}
}