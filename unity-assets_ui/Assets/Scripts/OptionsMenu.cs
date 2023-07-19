using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    private string _previousSceneName;

    private void Start()
    {
        _previousSceneName = SceneManager.GetActiveScene().name;
    }

    public void Back()
    {
        SceneManager.LoadScene(_previousSceneName);
    }
}
 
