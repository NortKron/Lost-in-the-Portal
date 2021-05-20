using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{
    GameObject trailUp;
    GameObject trailDown;

    void Start()
    {
        float k = 0.0f;

        trailUp = transform.Find("TrailUp").gameObject;
        trailDown = transform.Find("TrailDown").gameObject;
        
        float horDir;
        float verDir = trailUp.transform.position.y - trailDown.transform.position.y;

        if (trailUp.transform.position.x > trailDown.transform.position.x)
        {
            horDir = trailUp.transform.position.x - trailDown.transform.position.x;
        }
        else {
            horDir = trailDown.transform.position.x - trailUp.transform.position.x;
        }
        
        k = Vector3.Distance(trailUp.transform.position, trailDown.transform.position);

        /*
        Debug.Log("K = " + k 
            + "\nhorDir = " + horDir
            + "\nverDir = " + verDir);
        */
    }
}
