using System;
using TMPro;
using UnityEngine;

namespace Infrastructure.Service.Input
{
	public class ButtonInputService : MonoBehaviour, IInputService
	{
		public event Action<float> ChangeTimeScaleEvent;
		public event Action<float> PauseEvent;

		public TMP_Text SpeedValueText;
		public float ChangeTime = 0.2f;
		
		public void AddSpeed()
		{
			ChangeTimeScaleEvent?.Invoke(ChangeTime);
			SpeedValueText.text = "TimeSpeed:" + Time.timeScale;
		}

		public void RemoveSpeed()
		{
			ChangeTimeScaleEvent?.Invoke(-ChangeTime);
			SpeedValueText.text = "TimeSpeed:" + Time.timeScale;
		}
	}
}