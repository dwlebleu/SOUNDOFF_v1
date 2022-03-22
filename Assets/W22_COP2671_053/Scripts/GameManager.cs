using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    //spawn a new target every second
    private float spawnRate = 1.5f; 
    
    // Start is called before the first frame update
    void Start()
    {
         
        //call the Spawn Target method with a CoRoutine
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
