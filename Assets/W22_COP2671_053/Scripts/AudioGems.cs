using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//logic for sounds to play
public class AudioGems : MonoBehaviour
{
    //create a gem data type
    public enum gems
    { 
        good, bad, chord
    }

    public gems gemType;                 //create a variable of gems type
    public AudioSource audioSource;     //audio sources
    public AudioClip[] soundFiles;      //array for sound files
    private int clip_index;              //variable to get clip position in array


    // Start is called before the first frame update
    void Start()
    {
        audioSource.enabled = true;
        //assign audiosource clip to array index
        audioSource.clip = soundFiles[clip_index];
        

        //play the bad gem sound upon spwan
        if (gemType == gems.bad)
            audioSource.Play();
    }

    void Awake()
    {
        //assign random clip index to play
        clip_index = Random.Range(0, soundFiles.Length);

    }


}
