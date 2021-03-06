﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float hightWave = 0.1f;
    float periodWave = 2.0f;

    float timeWave = 1.0f;   

    bool isWaveUp = false;

    // Start is called before the first frame update
    void Start()
    {
        timeWave = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeWave >= periodWave)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                transform.position + (isWaveUp ? 1 : -1) * transform.up,
                hightWave);

            timeWave = Time.time;
            isWaveUp = !isWaveUp;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerEnter2D");

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Death");

            //GameObject player = GameObject.FindGameObjectWithTag("Player");
            //player.SendMessage("Death");
        }
    }
}
