using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;
    public GameObject timerCanvas;

    private bool _cutsceneFinished;

    private void Start()
    {
        player.GetComponent<PlayerController>().enabled = false;
        timerCanvas.SetActive(false);
    }

    private void Update()
    {
        if (_cutsceneFinished && Vector3.Distance(mainCamera.transform.position, player.transform.position) < 1f)
        {
            timerCanvas.SetActive(true);
        }
    }

    public void CutsceneAnimationFinished()
    {
        mainCamera.SetActive(true);
        player.GetComponent<PlayerController>().enabled = true;
        timerCanvas.SetActive(true);
        
        gameObject.SetActive(false);
    }
    
}