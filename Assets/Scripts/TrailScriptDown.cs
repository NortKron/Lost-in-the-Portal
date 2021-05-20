using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScriptDown : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Dealer - Trigger Enter");
            GameObject.FindGameObjectWithTag("GameController").SendMessage("ShowPanelMove");
            GameObject.FindGameObjectWithTag("Player").SendMessage("ChangeCanMoveUp");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Dealer - Trigger Exit");
            GameObject.FindGameObjectWithTag("GameController").SendMessage("ShowPanelMove");
            GameObject.FindGameObjectWithTag("Player").SendMessage("ChangeCanMoveUp");
        }
    }
}
