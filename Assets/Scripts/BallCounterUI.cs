using CoreGamePlay.Components;
using CoreGamePlay.Components.Waiters;
using TMPro;
using UnityEngine;

public class BallCounterUI : MonoBehaviour, IBallCounterWaiter
{
	public TMP_Text CountBallText;
	public TMP_Text SpeedValueText;
    public float ChangeTime = 0.2f;
    private BallCounter _counter;
    private bool _isInitialize;

    public void Constuct(BallCounter counter)
    {
	    _counter = counter;
	    _isInitialize = true;
    }

    public void Update()
    {
	    if (!_isInitialize)
		    return;
	    CountBallText.text = "Count ball: \n red:" +
	                         _counter.GetValue(BallType.Red) +
	                         "\n green:" +
							_counter.GetValue(BallType.Green) +
	                         "\n blue:" +
							_counter.GetValue(BallType.Blue) +
	                         "\n ";
    }

    public void AddSpeed()
    {
	    Time.timeScale += ChangeTime;
	    SpeedValueText.text = "TimeSpeed:" + Time.timeScale;
    }

    public void RemoveSpeed()
    {
	    Time.timeScale -= ChangeTime;
	    SpeedValueText.text = "TimeSpeed:" + Time.timeScale;
    }
}
