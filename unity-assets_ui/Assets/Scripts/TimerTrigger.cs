using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Timer timer = other.GetComponent<Timer>();
        
        if (timer != null)
        {
            timer.enabled = true;
        }
    }
}