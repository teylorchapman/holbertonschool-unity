using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;
    public GameObject timerCanvas;

    private bool _cutsceneFinished = false;

    private void Start()
    {
        player.GetComponent<PlayerController>().DisableMovement();
        timerCanvas.SetActive(false);
    }
    
    public void CutsceneAnimationFinished()
    {
        _cutsceneFinished = true;
        mainCamera.SetActive(true);
        player.GetComponent<PlayerController>().EnableMovement();
        timerCanvas.SetActive(true);
        
        gameObject.SetActive(false);
    }
    
    private void Update()
    {
        if (_cutsceneFinished && Vector3.Distance(mainCamera.transform.position, player.transform.position) < 1f)
        {
            timerCanvas.SetActive(true);
        }
    }
}