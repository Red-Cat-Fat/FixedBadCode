using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class greenBallClass : MonoBehaviour
{
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        var blueBalls = FindObjectsOfType<GreenTarget>();
        GetComponent<greenBallClass>().direction =
            blueBalls[Random.Range(0, blueBalls.Length)].transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x + direction.x*Time.deltaTime,
            transform.position.y + direction.y*Time.deltaTime,
            transform.position.z + direction.z*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BlueBall(Clone)")
        {
            var newGameObject = Instantiate(gameObject, transform.position + Random.insideUnitSphere.normalized * 2, Quaternion.identity);
            var blueBalls = FindObjectsOfType<GreenTarget>();
            newGameObject.GetComponent<greenBallClass>().direction =
                blueBalls[Random.Range(0, blueBalls.Length)].transform.position - newGameObject.transform.position;
            GameManager.inst.totalBals["green"]++;
        }

        if (collision.gameObject.name == "RedBall(Clone)" || collision.gameObject.name == "GreenBall(Clone)")
        {
            Destroy(this.gameObject);
            GameManager.inst.totalBals["green"]--;
        }
    }
}