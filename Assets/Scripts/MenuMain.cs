using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    public LevelController controller;

    public GameObject panelLoadingLevel;

    void Start()
    {
        //panelLoadingLevel = GameObject.Find("PanelLoading");
    }

    public void StartPressed()
    {
        Debug.Log("Start pressed!");

        panelLoadingLevel.SetActive(true);
        SceneManager.LoadScene("Level1");
    }

    public void ContinuePressed()
    {
        Debug.Log("Continue");
        controller.OnPause();
    }

    public void RetunMainMenuPressed()
    {
        Debug.Log("Return to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartPressed()
    {
        Debug.Log("Restart level");
        SceneManager.LoadScene(SceneManager.sceneCount);
    }

    public void ExitPressed()
    {
        Debug.Log("Quit pressed!");
        Application.Quit();        
    }
}
