using System;
using UnityEngine;

namespace Infrastructure.Service.Input
{
	public class KeyBoardInputService : MonoBehaviour, IInputService
	{
		public event Action<float> ChangeTimeScaleEvent;
		public event Action<float> PauseEvent;
		public float ChangeTime = 0.2f;

		public void Update()
		{
			if(UnityEngine.Input.GetKeyDown(KeyCode.A))
				ChangeTimeScaleEvent?.Invoke(-ChangeTime);
			
			if(UnityEngine.Input.GetKeyDown(KeyCode.D))
				ChangeTimeScaleEvent?.Invoke(ChangeTime);
		}
	}
}