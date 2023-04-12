using CoreGamePlay.Components;
using CoreGamePlay.Components.Balls;
using CoreGamePlay.Components.Balls.CollisionStrategies;
using CoreGamePlay.Components.Waiters;
using CoreGamePlay.Factories;
using UnityEngine;
using Random = UnityEngine.Random;

public class GreenBall : MonoBehaviour
{
	private Vector3 _direction;
	
	private void Start()
	{
		var blueBalls = FindObjectsOfType<GreenTarget>();
		GetComponent<GreenBall>()._direction =
			blueBalls[Random.Range(0, blueBalls.Length)].transform.position - transform.position;
	}

	private void Update()
	{
		transform.position = new Vector3(
			transform.position.x + _direction.x * Time.deltaTime,
			transform.position.y + _direction.y * Time.deltaTime,
			transform.position.z + _direction.z * Time.deltaTime);
	}
}