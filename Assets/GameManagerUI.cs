using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerUI : MonoBehaviour
{
    public TMP_Text countBall;
    public float changeTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
	    countBall = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        countBall.text = "Count ball: \n red:" +
                         GameManager.inst.totalBals["red"] +
                         "\n green:" +
                         GameManager.inst.totalBals["green"] +
                         "\n blue:" +
                         GameManager.inst.totalBals["blue"] +
                         "\n ";
    }

    public void AddSpeed()
    {
	    Time.timeScale += changeTime;
	    var texts = GetComponentsInChildren<TMP_Text>();
	    texts[3].text = "TimeSpeed:" + Time.timeScale;
    }
    public void RemoveSpeed()
    {
	    Time.timeScale -= changeTime;
	    var texts = GetComponentsInChildren<TMP_Text>();
	    texts[3].text = "TimeSpeed:" + Time.timeScale;
    }
}
