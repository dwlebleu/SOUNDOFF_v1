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
    public ParticleSystem splash;   //for the splash effect
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


    private void OnMouseDown()
    {
        //when game is over score code won't run
        if(gameManager.isGameActive)
        {
            //local var for gemsound
            var gemSound = GetComponent<AudioGems>();

            //if gem is not a bad gem...
            if (gemSound.gemType != AudioGems.gems.bad)
            {
                //play the good sounds
                gemSound.audioSource.Play();
                //destroy only after sound has finished playing
                Destroy(gameObject, gemSound.audioSource.clip.length);
                //add particle effects
                Instantiate(splash, transform.position, splash.transform.rotation);
            }
            else
            {
                //stop bad gem sound when clicked. 
                gemSound.audioSource.Stop();
                Destroy(gameObject);
                //add particle effects
                Instantiate(splash, transform.position, splash.transform.rotation);
            }

            
            //update the score for each clicked gem
            gameManager.UpdateScore(pointValue);

            //add particle effects
            //Instantiate(splash, transform.position, splash.transform.rotation);          
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }


}
