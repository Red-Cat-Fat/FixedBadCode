using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManagerUI : MonoBehaviour
{
    [FormerlySerializedAs("countBall")] 
    public TMP_Text CountBall;
    [FormerlySerializedAs("changeTime")] 
    public float ChangeTime = 0.2f;
    
    void Start()
    {
	    CountBall = GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        CountBall.text = "Count ball: \n red:" +
                         GameManager.Instance.totalBals["red"] +
                         "\n green:" +
                         GameManager.Instance.totalBals["green"] +
                         "\n blue:" +
                         GameManager.Instance.totalBals["blue"] +
                         "\n ";
    }

    public void AddSpeed()
    {
	    Time.timeScale += ChangeTime;
	    var texts = GetComponentsInChildren<TMP_Text>();
	    texts[3].text = "TimeSpeed:" + Time.timeScale;
    }
    
    public void RemoveSpeed()
    {
	    Time.timeScale -= ChangeTime;
	    var texts = GetComponentsInChildren<TMP_Text>();
	    texts[3].text = "TimeSpeed:" + Time.timeScale;
    }
}
