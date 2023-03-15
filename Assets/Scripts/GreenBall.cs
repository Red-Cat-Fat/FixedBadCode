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

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "BlueBall(Clone)")
		{
			var newGameObject = Instantiate(
				gameObject,
				transform.position + Random.insideUnitSphere.normalized * 2,
				Quaternion.identity);
			var blueBalls = FindObjectsOfType<GreenTarget>();
			newGameObject.GetComponent<GreenBall>()._direction =
				blueBalls[Random.Range(0, blueBalls.Length)].transform.position - newGameObject.transform.position;
			GameManager.Instance.totalBals["green"]++;
		}

		if (collision.gameObject.name == "RedBall(Clone)" || collision.gameObject.name == "GreenBall(Clone)")
		{
			Destroy(this.gameObject);
			GameManager.Instance.totalBals["green"]--;
		}
	}
}