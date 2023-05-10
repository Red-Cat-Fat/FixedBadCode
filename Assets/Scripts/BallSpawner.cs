using CoreGamePlay.Factories;
using Infrastructure.Service.Times;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
	private float _timeSpawn = 1;
	public int RadiusSpawn;

	private float _curTime;
	private bool _isInitialize;
	private BallFactory _factory;
	private ITimeService _timeService;

	public void Construct(ITimeService timeService, BallFactory factory, float timeSpawn)
	{
		_timeService = timeService;
		_isInitialize = true;
		_factory = factory;
		_timeSpawn = timeSpawn;
	}
	
	private void Update()
	{
		if(!_isInitialize)
			return;
		
		_curTime -= _timeService.DeltaTime;
		if (_curTime < 0)
		{
			_factory.SpawnBall(Random.insideUnitSphere * RadiusSpawn);
			_curTime += _timeSpawn; 
		}
	}
}