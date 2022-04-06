using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody targetRb;
    private float minSpeed = 0.5f;
    private float maxSpeed = 1.5f;
    private float maxTorque = 5;
    private float xRange = 10;      //range of the X pos of board
    private float ySpawnPos = 4;     //range of the Y pos of board

    public ParticleSystem splash;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

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
        //when game is over score code won't run
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            //add particle effects
            gameManager.UpdateScore(pointValue);

            Instantiate(splash, transform.position, splash.transform.rotation);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }


}
