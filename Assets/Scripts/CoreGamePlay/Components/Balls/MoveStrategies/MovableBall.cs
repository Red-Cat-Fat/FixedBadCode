using UnityEngine;

namespace CoreGamePlay.Components.Balls.MoveStrategies
{
	[RequireComponent(typeof(Rigidbody))]
	public abstract class MovableBall : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _rigidbody;

		protected void MovePosition(Vector3 shift)
		{
			_rigidbody.MovePosition(_rigidbody.position + shift);
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			_rigidbody = GetComponent<Rigidbody>();
			DoValidate();
		}
#endif
		protected virtual void DoValidate()
		{
			
		}
	}
}