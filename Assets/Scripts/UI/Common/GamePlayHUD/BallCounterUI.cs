using TMPro;
using UnityEngine;

namespace UI.Common.GamePlayHUD
{
	public class BallCounterUI : MonoBehaviour
	{
		public TMP_Text CountBallText;
		private BallCounter _counter;
		private bool _isInitialize;

		public void Construct(BallCounter counter)
		{
			_counter = counter;
			_isInitialize = true;
		}

		public void Update()
		{
			if (!_isInitialize)
				return;

			CountBallText.text = "Count ball: \n red:"
				+ _counter.GetValue(BallType.Red)
				+ "\n green:"
				+ _counter.GetValue(BallType.Green)
				+ "\n blue:"
				+ _counter.GetValue(BallType.Blue)
				+ "\n ";
		}
	}
}