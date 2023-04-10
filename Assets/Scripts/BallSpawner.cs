using CoreGamePlay.Components.Waiters;
using CoreGamePlay.Factories;
using UnityEngine;
using UnityEngine.Serialization;

public class BallSpawner : MonoBehaviour, IBallCounterWaiter
{
	[FormerlySerializedAs("prefab")] 
	public GameObject Prefab;
	[FormerlySerializedAs("transformSpawn")]
	public Transform TransformSpawn;
	[FormerlySerializedAs("time")]
	public float TimeSpawn = 1;
	[FormerlySerializedAs("_radius")] [FormerlySerializedAs("radius")] 
	public int RadiusSpawn;

	private float _curTime;
	private BallCounter _counter;
	private bool _isInitialize = false;
	private BallFactory _factory;
	
	public void Constuct(BallCounter counter)
	{
		_counter = counter;
		_isInitialize = true;
		_factory = new BallFactory(Prefab.tag, Prefab, _counter);
	}
	
	private void Update()
	{
		if(!_isInitialize)
			return;
		
		_curTime -= UnityEngine.Time.deltaTime;
		if (_curTime < 0)
		{
			_factory.SpawnBall(Random.insideUnitSphere * RadiusSpawn);
			_curTime = TimeSpawn;
		}
	}
}