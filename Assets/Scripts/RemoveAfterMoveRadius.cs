using System;
using UnityEngine;
using UnityEngine.Serialization;

public class RemoveAfterMoveRadius : MonoBehaviour
{
    [FormerlySerializedAs("ballType")] 
    public string BallType;

    private ZeroPosition _zero;

    public void Awake()
    {
        _zero = FindObjectOfType<ZeroPosition>();
    }

    public void Update()
    {
        if (Vector3.Distance(transform.position, _zero.transform.position) > _zero.Distance)
        {
            GameManager.Instance.TotalBals[BallType]--;
            Destroy(gameObject); 
        }
    }
}
