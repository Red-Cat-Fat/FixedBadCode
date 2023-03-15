using UnityEngine;
using UnityEngine.Serialization;

public class RandomVelocity : MonoBehaviour
{
    [FormerlySerializedAs("TimeRandomize")] [FormerlySerializedAs("tr")] 
    public float RandomCooldown = 1f;
    [FormerlySerializedAs("rv")] 
    public float RandovVelocity = 5;
    float time = 0;
    
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * RandovVelocity;
            time = RandomCooldown;
        }
    }
}
