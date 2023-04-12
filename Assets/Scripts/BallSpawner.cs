using CoreGamePlay.Factories;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
	private float _timeSpawn = 1;
	public int RadiusSpawn;

	private float _curTime;
	private bool _isInitialize;
	private BallFactory _factory;
	
	public void Construct(BallFactory factory, float timeSpawn)
	{
		_isInitialize = true;
		_factory = factory;
		_timeSpawn = timeSpawn;
	}
	
	private void Update()
	{
		if(!_isInitialize)
			return;
		
		_curTime -= UnityEngine.Time.deltaTime;
		if (_curTime < 0)
		{
			_factory.SpawnBall(Random.insideUnitSphere * RadiusSpawn);
			_curTime += _timeSpawn; 
		}
	}
}