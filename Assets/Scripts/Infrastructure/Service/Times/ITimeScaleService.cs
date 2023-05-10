namespace Infrastructure.Service.Times
{
	public interface ITimeScaleService : IService
	{
		float DeltaTime { get; }
		float TimeScale { get; }
	}
}