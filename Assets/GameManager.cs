using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    public int countBalls = 0;
    public Dictionary<string, int> totalBals = new Dictionary<string, int>();
    
    private void Awake()
    {
        inst = this;
        DontDestroyOnLoad(this);
        
        GameManager.inst.totalBals["red"] = 0;
        GameManager.inst.totalBals["green"] = 0;
        GameManager.inst.totalBals["blue"] = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
