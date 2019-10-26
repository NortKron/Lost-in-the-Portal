using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    public void StartPressed()
    {
        Debug.Log("Start pressed!");
        SceneManager.LoadScene("Level1");
    }
    public void ExitPressed()
    {
        Debug.Log("Quit pressed!");
        Application.Quit();
    }
}
