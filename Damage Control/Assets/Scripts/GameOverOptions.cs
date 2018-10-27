using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOptions : MonoBehaviour
{
    [SerializeField]
    private float secondsBeforeAutomaticRestart = 15;

    private void Start()
    {
        StartCoroutine(QuitCountdown());
    }

    private IEnumerator QuitCountdown()
    {
        yield return new WaitForSeconds(secondsBeforeAutomaticRestart);
        GoToTitleScreen();
    }

    public void Restart()
    {
        LevelManager.instance.RestartGame();
    }

    public void GoToTitleScreen()
    {
        LevelManager.instance.GoToTitleScreen();
    }
}
