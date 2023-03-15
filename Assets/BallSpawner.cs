using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform transformSpawn;
    public float time = 1;
    public int radius;
    float curTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime -= Time.deltaTime;
        if (curTime < 0)
        {
            GameObject.Instantiate(prefab, Random.insideUnitSphere * radius, Quaternion.identity, transformSpawn);
            GameManager.inst.countBalls++;
            GameManager.inst.totalBals[prefab.tag]++;
            Debug.Log(prefab.tag + " заспавнили!!!!!");
            curTime = time;
        }
    }
}
