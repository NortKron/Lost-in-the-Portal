using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    // Скрипт торговца

    List<string> dialog = new List<string>(){
        "Уиха: Привет",
        "Торговец: Привет, Уиха!",
        "Уиха: Хочешь расскажу смешной анекдот?",
        "Торговец: Нет",
        "Уиха: Тогда бывай"
    };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Dealer - Trigger Enter");
            GameObject.FindGameObjectWithTag("GameController").SendMessage("ShowPanelTalk");
            GameObject.FindGameObjectWithTag("GameController").SendMessage("GetDialog", dialog);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Dealer - Trigger Exit");
            GameObject.FindGameObjectWithTag("GameController").SendMessage("ShowPanelTalk");
        }
    }
}
