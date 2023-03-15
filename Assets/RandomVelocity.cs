using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVelocity : MonoBehaviour
{
    public float tr = 1f;
    public float rv = 5;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * rv;
            time = tr;
        }
    }
}
