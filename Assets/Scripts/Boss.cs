using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float damage = 1.0f;

    List<string> dialog = new List<string>(){
        "Уиха: Что ты за существо?",
        "Босс: Буэээ",
        "Уиха: Сдохни!",
        "Босс: Аххрг! <подыхает>",
        "Уиха: Вуух! <вздох облегчения>"
    };

    void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Boss - Collision");
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.SendMessage("GetDamage", damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectsWithTag("GameController")[0].SendMessage("ShowPanelTalk");
            GameObject.FindGameObjectsWithTag("GameController")[0].SendMessage("GetDialog", dialog);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Boss - Trigger Exit");
            GameObject.FindGameObjectsWithTag("GameController")[0].SendMessage("ShowPanelTalk");
        }
    }        
}
