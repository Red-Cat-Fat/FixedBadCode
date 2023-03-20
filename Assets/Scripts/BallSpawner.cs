using CoreGamePlay.Components.Waiters;
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
	public void Constuct(BallCounter counter)
	{
		_counter = counter;
		_isInitialize = true;
	}
	
	private void Update()
	{
		if(!_isInitialize)
			return;
		
		_curTime -= UnityEngine.Time.deltaTime;
		if (_curTime < 0)
		{
			var newBall = GameObject.Instantiate(
				Prefab,
				Random.insideUnitSphere * RadiusSpawn,
				Quaternion.identity,
				TransformSpawn);

			var ballWaiters = newBall.GetComponents<IBallCounterWaiter>();
			foreach (var waiter in ballWaiters) 
				waiter.Constuct(_counter);
			
			_counter.TotalBals[Prefab.tag]++;
			Debug.Log(Prefab.tag + " заспавнили!!!!!");
			_curTime = TimeSpawn;
		}
	}
}