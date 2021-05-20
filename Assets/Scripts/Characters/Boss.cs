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
            collision.gameObject.SendMessage("GetDamage", damage);

            //Debug.Log("Boss - Collision");
            //GameObject.FindGameObjectsWithTag("Player")[0].SendMessage("GetDamage", damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("GameController").SendMessage("ShowPanelTalk");
            GameObject.FindGameObjectWithTag("GameController").SendMessage("GetDialog", dialog);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Boss - Trigger Exit");
            GameObject.FindGameObjectWithTag("GameController").SendMessage("ShowPanelTalk");
        }
    }        
}
