using UnityEngine;

public class RemoveAfterMoveRadius : MonoBehaviour
{
	private ZeroPosition _zero;

	public void Awake()
	{
		_zero = FindObjectOfType<ZeroPosition>();
	}

	public void Update()
	{
		if (Vector3.Distance(transform.position, _zero.transform.position) > _zero.Distance)
		{
			Destroy(gameObject);
		}
	}
}