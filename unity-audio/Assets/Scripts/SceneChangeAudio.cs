using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeAudio : MonoBehaviour
{
    private AudioSource bgMusic;

    private void Start()
    {
        bgMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "MainMenu")
            bgMusic.Stop();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; }
}
