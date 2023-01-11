using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public GameObject background;
    private AudioSource audio;
    private bool curr_state;

    // Start is called before the first frame update
    void Start()
    {
        curr_state = false;
        audio = background.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeBackground()
    {
        background.SetActive(!curr_state);
        audio.mute = curr_state;
        curr_state = !curr_state;
    }
}
