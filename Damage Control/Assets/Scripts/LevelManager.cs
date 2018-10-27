using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

    [SerializeField]
    private string titleScreen;


    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public void RestartGame()
    {
        ResetTimeScale();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Quit()
    {
        ResetTimeScale();
        Application.Quit();
    }

    public void GoToTitleScreen()
    {
        ResetTimeScale();
        SceneManager.LoadScene(titleScreen);
    }

    private void ResetTimeScale()
    {
        Time.timeScale = 1;
    }
}
