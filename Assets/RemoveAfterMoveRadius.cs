using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfterMoveRadius : MonoBehaviour
{
    public string ballType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var zero = FindObjectOfType<ZeroPosition>();
        if (Vector3.Distance(transform.position, zero.transform.position) > zero.distance)
        {
            GameManager.inst.totalBals[ballType]--;
            Destroy(gameObject);
        }
    }
}
