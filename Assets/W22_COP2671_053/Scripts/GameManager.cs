using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    //for our score text
    public TextMeshProUGUI scoreText;

    //spawn a new target every second
    private float spawnRate = 1.5f;

    //variable to store score
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
         
        //call the Spawn Target method with a CoRoutine
        StartCoroutine(SpawnTarget());

        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore(0);
    }

   
    IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);

            //get a random object from the list to use
            //random number between first object and last object
            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

}
