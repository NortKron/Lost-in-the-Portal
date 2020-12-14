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
            GameObject.FindGameObjectsWithTag("GameController")[0].SendMessage("ShowPanelMove");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Dealer - Trigger Exit");
            GameObject.FindGameObjectsWithTag("GameController")[0].SendMessage("ShowPanelMove");
        }
    }
}
