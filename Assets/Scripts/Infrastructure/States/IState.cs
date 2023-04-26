namespace Infrastructure.States
{
	public interface IState
	{
		void Enter();
	}

	public interface IStatePayload<T> : IState
	{
		void Enter(T payloadData);
	}
}