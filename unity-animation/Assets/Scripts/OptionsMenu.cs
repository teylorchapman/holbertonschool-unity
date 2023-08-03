using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYAxisToggle;
    public static string _previousSceneName;
    public static int level;
    
    public void Start()
    {
        _previousSceneName = SceneManager.GetActiveScene().name;
        if (PlayerPrefs.HasKey("InvertYAxis"))
        {
            bool isInverted = PlayerPrefs.GetInt("InvertYAxis") == 1;
            invertYAxisToggle.isOn = isInverted;
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(_previousSceneName);
    }

    public void Apply()
    {
        int isInvertedValue = invertYAxisToggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("InvertYAxis", isInvertedValue);

        SceneManager.LoadScene(level);
    }
}