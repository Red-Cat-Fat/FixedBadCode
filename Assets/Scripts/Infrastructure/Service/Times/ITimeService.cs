namespace Infrastructure.Service.Times
{
	public interface ITimeService : IService
	{
		float DeltaTime { get; }
	}
}