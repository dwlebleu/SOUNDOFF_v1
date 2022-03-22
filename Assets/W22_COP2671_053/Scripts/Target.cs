using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 0.5f;
    private float maxSpeed = 1.5f;
    private float maxTorque = 10;
    private float xRange = 10;      //range of the X pos of board
    private float ySpawnPos = 4;     //range of the Y pos of board

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);

        //rotate object as it moves
        targetRb.AddTorque(Random.Range(-maxTorque,  maxTorque), 5, 0);

        //get position of current object
        transform.position = new Vector3(Random.Range(-xRange, xRange), Random.Range(-ySpawnPos, ySpawnPos)); //no Z
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }


}
