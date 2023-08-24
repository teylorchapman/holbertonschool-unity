using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WinTrigger : MonoBehaviour
{
    public GameObject winCanvas;
    private AudioSource myMusic;
    public AudioSource gameMusic;
    private AudioSource BGM;


    void Start()
    {
        myMusic = gameObject.GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        Timer otherTimer = other.GetComponent<Timer>();
        
        if (otherTimer != null)
            {
                otherTimer.enabled = false;
            }

        winCanvas.SetActive(true);
        // add in an update text to update the timer
        
        myMusic.Play();
        gameMusic.Stop();
        BGM.Stop();
    }
}
