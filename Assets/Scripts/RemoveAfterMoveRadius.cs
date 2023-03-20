using System;
using CoreGamePlay.Components;
using CoreGamePlay.Components.Waiters;
using UnityEngine;
using UnityEngine.Serialization;

public class RemoveAfterMoveRadius : MonoBehaviour, IBallCounterWaiter
{
    [FormerlySerializedAs("ballType")] 
    public string BallType;

    private ZeroPosition _zero;
    private BallCounter _counter;

    public void Constuct(BallCounter counter)
    {
        _counter = counter;
    }

    public void Awake()
    {
        _zero = FindObjectOfType<ZeroPosition>();
    }

    public void Update()
    {
        if (Vector3.Distance(transform.position, _zero.transform.position) > _zero.Distance)
        {
            _counter.TotalBals[BallType]--;
            Destroy(gameObject); 
        }
    }
}
