using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool _isPaused;
    private float _previousTimeScale;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        _previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
    }

    public void Resume()
    {
        _isPaused = false;
        Time.timeScale = _previousTimeScale;
        pauseCanvas.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
