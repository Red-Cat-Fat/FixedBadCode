using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class RandomVelocity : MonoBehaviour
{
    public float RandomCooldown = 1f;
    public float RandovVelocity = 5;
    float time = 0;
    
    public Rigidbody _rigidbody;

    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            _rigidbody.velocity = Random.insideUnitSphere * RandovVelocity;
            time = RandomCooldown;
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    { 
        _rigidbody = GetComponent<Rigidbody>();
    }
#endif
}
