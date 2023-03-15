using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BallSpawner : MonoBehaviour
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

	void Update()
	{
		_curTime -= UnityEngine.Time.deltaTime;
		if (_curTime < 0)
		{
			GameObject.Instantiate(
				Prefab,
				Random.insideUnitSphere * RadiusSpawn,
				Quaternion.identity,
				TransformSpawn);
			GameManager.Instance.CountBalls++;
			GameManager.Instance.totalBals[Prefab.tag]++;
			Debug.Log(Prefab.tag + " заспавнили!!!!!");
			_curTime = TimeSpawn;
		}
	}
}