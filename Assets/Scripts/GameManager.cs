using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [FormerlySerializedAs("countBalls")] 
    public int CountBalls = 0;
    public Dictionary<string, int> totalBals = new Dictionary<string, int>();
    
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        
        GameManager.Instance.totalBals["red"] = 0;
        GameManager.Instance.totalBals["green"] = 0;
        GameManager.Instance.totalBals["blue"] = 0;
    }
}
