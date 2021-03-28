﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float hightWave = 0.1f;
    public float periodWave = 2.0f;

    bool isWaveUp = true;

    // Start is called before the first frame update
    void Start()
    {
        // Запуск колебания поверхности воды с периодом periodWave
        InvokeRepeating("WaveMoving", 1.0f, periodWave);
    }

    void WaveMoving()
    {
        transform.position = Vector3.MoveTowards(
                transform.position,
                transform.position + (isWaveUp ? 1 : -1) * transform.up,
                hightWave);

        isWaveUp = !isWaveUp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Death");
        }
    }
}
