using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : Singleton<Game>
{
    public override void Awake()
    {
        Debug.Log("Awake Game");
        MainMenuPanel.OnStartPressed += LoadLevel;
        EndGamePanel.OnSessionRestartPressed += TryAgain;
        EndGamePanel.OnEndSessionPressed += Quit;

    }

    private void OnDestroy()
    {
        Debug.Log("Destroy Game");
        MainMenuPanel.OnStartPressed -= LoadLevel;
        EndGamePanel.OnSessionRestartPressed -= TryAgain;
        EndGamePanel.OnEndSessionPressed -= Quit;
    }

    private void LoadLevel()
    {
        Debug.Log("Start game");
        SceneManager.LoadScene("SampleScene");
    }

    private void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    private void TryAgain()
    {
        Debug.Log("Try Again");
        SceneManager.LoadScene("InitialScene");
    }
}
