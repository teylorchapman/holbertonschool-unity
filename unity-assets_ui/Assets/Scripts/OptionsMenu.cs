using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public static int _previousSceneName;
    

    public void Back()
    {
        SceneManager.LoadScene(_previousSceneName);
    }
}
 
