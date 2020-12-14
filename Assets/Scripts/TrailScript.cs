using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{
    GameObject trailUp;
    GameObject trailDowm;

    void Start()
    {
        trailUp = transform.Find("TrailUp").gameObject;
        trailDowm = transform.Find("TrailDown").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trail - Trigger Enter");
        GameObject.FindGameObjectsWithTag("Player")[0].SendMessage("ChangeCanMoveUp");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trail - Trigger Exit");
        GameObject.FindGameObjectsWithTag("Player")[0].SendMessage("ChangeCanMoveUp");
    }
}
