using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float top = 7;
    private float bottom = -7;
    private float leftSide = -13;
    private float rightSide = 13;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy objects if ever off screen
        if(transform.position.y > top)
            Destroy(gameObject);
        else if(transform.position.y < bottom)
            Destroy(gameObject);
        else if(transform.position.x > rightSide)
            Destroy(gameObject);
        else if(transform.position.x < leftSide)
            Destroy(gameObject);

    }
}
