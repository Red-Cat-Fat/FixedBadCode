using System;
using UnityEngine;

namespace CoreGamePlay.Components.Triggers
{
	public class OnDestroyTrigger : MonoBehaviour
	{
		public event Action<GameObject> DestroyEvent;
		
		private void OnDestroy()
		{
			DestroyEvent?.Invoke(gameObject);
		}
	}
}