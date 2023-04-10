using CoreGamePlay.Components;
using CoreGamePlay.Components.Waiters;
using CoreGamePlay.Factories;
using UnityEngine;
using Random = UnityEngine.Random;

public class GreenBall : MonoBehaviour, IBallCounterWaiter
{
	private Vector3 _direction;
	private BallCounter _counter;

	private BallFactory _factory;

	public void Constuct(BallCounter counter)
	{
		_counter = counter;
		_factory = new BallFactory(BallType.Green, gameObject, _counter);
	}
	
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

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "BlueBall(Clone)")
		{
			_factory.SpawnBall(transform.position + Random.insideUnitSphere.normalized * 2);
		}

		if (collision.gameObject.name == "RedBall(Clone)" || collision.gameObject.name == "GreenBall(Clone)")
		{
			Destroy(this.gameObject);
			_counter.DelBall(BallType.Green);
		}
	}
}