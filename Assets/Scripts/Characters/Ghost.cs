    using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Ghost : MonoBehaviour
{
    public float damage = 1.0f;

    float upperLimit = 0.1f;
    float verticalSpeed = 0.3f;

    float sideLimit = 0.7f;
    float horizontalSpeed = 0.3f;

    float crdY = 0.0f;
    float crdX = 0.0f;

    float delayStart = 0.0f;
    float timeStart = 0.0f;

    bool isMoveUp = true;
    bool isMoveForward = true;

    SpriteRenderer sprite;
    private GameObject labelLeftUp;

    // Start is called before the first frame update
    void Start()
    {
        delayStart = Random.Range(0.0f, 1.0f);
        isMoveUp = Random.value < 0.15;

        timeStart = Time.time;

        crdY = transform.position.y;
        crdX = transform.position.x;

        sprite = GetComponentInChildren<SpriteRenderer>();

        //Debug.Log(crdY);
        labelLeftUp = GameObject.Find("Label_LeftUp");

        transform.position = new Vector3(
                transform.position.x,
                Random.Range(crdY - upperLimit, crdY + upperLimit),
                transform.position.z);

        //Debug.Log("del : " + delayStart);
    }

    // Update is called once per frame
    void Update()
    {
        //labelLeftUp.GetComponent<Text>().text = "X = " + transform.position.x + " ; Y = " + transform.position.y + ";";
        //transform.position = Vector3.MoveTowards(transform.position, transform.position - transform.up, verticalSpeed * Time.deltaTime);               

        // Чтобы привидения двигались асинхронно
        //if (Time.time - timeStart < delayStart) return;

        //labelLeftUp.GetComponent<Text>().text = "Y : " + transform.position.y;

        /*
        if ((transform.position.y + verticalSpeed >= crdY - upperLimit && isMoveUp) ||
                 (transform.position.y + verticalSpeed <= crdY + upperLimit && !isMoveUp))

            transform.position = Vector3.MoveTowards(
                transform.position,
                //transform.position - transform.up,
                transform.position + (isMoveUp ? 1 : -1) * transform.up,
                verticalSpeed * Time.deltaTime);
        else
            isMoveUp = !isMoveUp;
        */
        
        if (isMoveUp)
        {
            if (transform.position.y + verticalSpeed >= crdY - upperLimit)
                transform.position = Vector3.MoveTowards(
                    transform.position, 
                    transform.position - transform.up,
                    verticalSpeed * Time.deltaTime);
            else
                isMoveUp = !isMoveUp;
        }
        else
        {
            if (transform.position.y + verticalSpeed <= crdY + upperLimit)
                transform.position = Vector3.MoveTowards(
                    transform.position, 
                    transform.position + transform.up, 
                    verticalSpeed * Time.deltaTime);
            else
                isMoveUp = !isMoveUp;
        }
        /*
        if (isMoveForward)
        {
            if (transform.position.x + horizontalSpeed <= crdX + sideLimit)
                transform.position = Vector3.MoveTowards(
                    transform.position, 
                    transform.position + transform.right, 
                    horizontalSpeed * Time.deltaTime);
            else
            {
                sprite.flipX = isMoveForward;
                isMoveForward = !isMoveForward;
            }
        }
        else
        {
            if (transform.position.x - horizontalSpeed >= crdX - sideLimit)
                transform.position = Vector3.MoveTowards(
                    transform.position, 
                    transform.position - transform.right, 
                    horizontalSpeed * Time.deltaTime);
            else
            {
                sprite.flipX = isMoveForward;
                isMoveForward = !isMoveForward;
            }
        }
        */

        // Запуск колебания поверхности воды с периодом periodWave
        //InvokeRepeating("GhostMoving", 1.0f, 0.0f);

    }

    private void GhostMoving()
    {
        transform.position = Vector3.MoveTowards(
               transform.position,
               transform.position + (isMoveUp ? 1 : -1) * transform.up,
               verticalSpeed * Time.deltaTime);

        isMoveUp = !isMoveUp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerEnter2D");

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("GetDamage", damage);
            //GameObject player = GameObject.FindGameObjectWithTag("Player");
            //player.SendMessage("GetDamage", damage);
        }
    }   
}
