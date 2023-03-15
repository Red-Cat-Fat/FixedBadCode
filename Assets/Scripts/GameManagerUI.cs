using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManagerUI : MonoBehaviour
{
	public TMP_Text CountBallText;
	public TMP_Text SpeedValueText;
    public float ChangeTime = 0.2f;

    public void Update()
    {
	    CountBallText.text = "Count ball: \n red:" +
	                         GameManager.Instance.TotalBals["red"] +
	                         "\n green:" +
	                         GameManager.Instance.TotalBals["green"] +
	                         "\n blue:" +
	                         GameManager.Instance.TotalBals["blue"] +
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
