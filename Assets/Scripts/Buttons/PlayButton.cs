using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private const string _gameScene = "Game";

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_gameScene, LoadSceneMode.Single);
    }
}
