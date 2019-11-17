using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float damage = 1.0f;

    void OnCollisionEnter2D(Collision2D collision)
    {

        //Debug.Log("Collision");
        
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];

            player.SendMessage("GetDamage", damage);

        }
    }
}
