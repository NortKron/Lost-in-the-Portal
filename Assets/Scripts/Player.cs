using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Lives = 10.0f;
    public float WalkSpeed = 1.0f;
    public float JumpForce = 2.0f;

    public GameObject MainCamera;

    // Plauer GUI
    private GameObject panelPlayerGUI;

    public GameObject panelLabelDeath;

    // labels
    private GameObject labelLeftUp;
    private GameObject labelRightDown;

    //private bool isPause = false;
    //private bool isOpenInventory = false;
    public bool isDied = false;

    new Rigidbody2D rigidbody;
    Animator animator;
    SpriteRenderer sprite;

    private MoveState moveState = MoveState.Idle;

    enum MoveState
    {
        Idle,
        Walk,
        Jump
    }

    // Start is called before the first frame update
    void Start()
    {
        // Mouse cursor visible
        Cursor.visible = false;

        Time.timeScale = 1;

        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        //panelMenuPause = GameObject.Find("Menu_Pause");

        panelPlayerGUI = GameObject.Find("Player_GUI");

        labelLeftUp = GameObject.Find("Label_LeftUp");
        labelRightDown = GameObject.Find("Label_RightDown");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(labelLeftUp.GetComponent<Text>().text);

        //labelLeftUp.GetComponent<Text>().text = "X = " + transform.position.x + " ; Y = " + transform.position.y + ";" ;
        labelRightDown.GetComponent<Text>().text = "Lives : " + Lives;
    }

    void Walk()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, WalkSpeed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0f;

        if (moveState != MoveState.Jump)
        {
            moveState = MoveState.Walk;
            animator.Play("Walk");
        }
    }

    void Jump()
    {
        if (moveState != MoveState.Jump)
        {
            rigidbody.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);

            moveState = MoveState.Jump;
            animator.Play("Jump");
        }
    }

    private void Idle()
    {
        moveState = MoveState.Idle;
        animator.Play("Idle");
    }

    public void GetDamage(float damagePoint)
    {
        Lives -= damagePoint;

        if (Lives < 1)
        {
            Death();
        }
    }

    public void Death()
    {
        // Включить анимацию смерти
        moveState = MoveState.Idle;
        animator.Play("Idle");

        //Debug.Log("Die");

        labelRightDown.GetComponent<Text>().text = "Lives : 0";

        isDied = true;
        panelLabelDeath.SetActive(true);
    }
}
