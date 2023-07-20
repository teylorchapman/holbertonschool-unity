using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Options()
    {
        OptionsMenu._previousSceneName = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene("Options");
        
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
    
}
