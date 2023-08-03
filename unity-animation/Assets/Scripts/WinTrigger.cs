using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject winCanvas;
    void OnTriggerEnter(Collider other)
    {
        Timer otherTimer = other.GetComponent<Timer>();
        
        if (otherTimer != null)
            {
                otherTimer.enabled = false;
            }

        winCanvas.SetActive(true);
        // add in an update text to update the timer
    }
}
