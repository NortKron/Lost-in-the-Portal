using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    public Player player;

    public void StartPressed()
    {
        Debug.Log("Start pressed!");
        SceneManager.LoadScene("Level1");
    }

    public void ContinuePressed()
    {
        Debug.Log("Continue");
        player.OnPause();
    }

    public void RetunMainMenuPressed()
    {
        Debug.Log("Return to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitPressed()
    {
        Debug.Log("Quit pressed!");
        Application.Quit();
    }
}
