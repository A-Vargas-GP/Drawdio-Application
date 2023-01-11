using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{

    AudioSource mouse_audio;

    public AudioClip draw_forest;

    public bool AudioOn;


     void Start()
    {
        mouse_audio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().playOnAwake = true;
        mouse_audio.volume = 0f;
        AudioOn = false;
    }

void StartMusic()
    {
        //Sets to false if hamburger button is not selected --> go draw
        //Sets to true if hamburger button is selected --> do not draw 

        //Mouse is held down OR pressed
        if (Input.GetKeyDown(KeyCode.Mouse0) == true || Input.GetKey(KeyCode.Mouse0) == true)
        {
            AudioOn = true;
            //GetComponent<AudioSource>().PlayOneShot(draw_forest, 0.7f);
            Debug.Log(AudioOn);
            mouse_audio.volume = 0.7f;
        }
        //Mouse is released
        else
        {
            AudioOn=false;
            mouse_audio.volume = 0f;
            //GetComponent<AudioSource>().Stop();
        }
    }

    void Update()
    {
         StartMusic();

    }
}
