using UnityEngine;
using UnityEngine.Serialization;

public class RemoveAfterMoveRadius : MonoBehaviour
{
    [FormerlySerializedAs("ballType")] 
    public string BallType;
    
    void Update()
    {
        var zero = FindObjectOfType<ZeroPosition>();
        if (Vector3.Distance(transform.position, zero.transform.position) > zero.Distance)
        {
            GameManager.Instance.totalBals[BallType]--;
            Destroy(gameObject); 
        }
    }
}
