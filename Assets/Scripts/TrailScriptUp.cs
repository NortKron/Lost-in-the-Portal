using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScriptUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trail - Trigger Enter");
        GameObject.FindGameObjectWithTag("GameController").SendMessage("ShowPanelMove");
        GameObject.FindGameObjectWithTag("Player").SendMessage("ChangeCanMoveDown");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Trail - Trigger Exit");
        GameObject.FindGameObjectWithTag("GameController").SendMessage("ShowPanelMove");
        GameObject.FindGameObjectWithTag("Player").SendMessage("ChangeCanMoveDown");
    }
}
