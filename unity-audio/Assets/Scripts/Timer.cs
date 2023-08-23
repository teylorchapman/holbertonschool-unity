using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public Text FinalTime;
    private float elapsedTime;
    private bool hasWon;

    private void Start()
    {
        elapsedTime = 0f;
    }

    void OnDisable()
    {
        TimerText.color = Color.green;
        TimerText.fontSize = 60;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        int minutes = (int)(elapsedTime / 60f);
        int seconds = (int)(elapsedTime % 60f);
        int milliseconds = (int)((elapsedTime * 100f) % 100f);

        TimerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }

    public void Win()
    {
        if (!hasWon)
        {
            hasWon = true;
            FinalTime.text = TimerText.text;
        }
    }
}