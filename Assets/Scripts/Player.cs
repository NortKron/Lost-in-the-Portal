using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.GlobalIllumination;

public class Player : MonoBehaviour
{
    public int kUp = 1;
    public int kDown = 1;

    public float Lives = 10.0f;
    public float WalkSpeed = 1.0f;
    public float JumpForce = 2.0f;

    public float dirHoriz = 1.8f;

    public GameObject MainCamera;

    // Plauer GUI
    private GameObject panelPlayerGUI;

    public GameObject panelLabelDeath;

    // labels
    private GameObject labelLeftUp;
    private GameObject labelRightDown;

    public bool isDied = false;
    private bool isCanMoveUp = false;
    private bool isCanMoveDown = false;

    bool movingVertical = false;

    new Rigidbody2D rigidbody;
    Animator animator;
    SpriteRenderer sprite;

    private MoveState moveState = MoveState.Idle;

    enum MoveState
    {
        Idle,
        Walk,
        Jump,
        MoveUp,
        MoveDown
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

        labelLeftUp.GetComponent<Text>().text = "X = " + transform.position.x + " ; Y = " + transform.position.y + ";" ;
        labelRightDown.GetComponent<Text>().text = "Lives : " + Lives;

        /*
        if (playMoving)
        {   
            transform.position = Vector3.MoveTowards(
                transform.position,
                transform.up * Input.GetAxis("Vertical"), 
                WalkSpeed * Time.deltaTime);
        }
        */
    }

    void Walk()
    {
        //Debug.Log("Walk");

        //Debug.Log("H : " + Input.GetAxis("Horizontal"));
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position + direction,
            //transform.right * Input.GetAxis("Horizontal"),
            WalkSpeed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0f;

        if (moveState != MoveState.Jump)
        {
            moveState = MoveState.Walk;
            animator.Play("Walk");
        }
    }

    void WalkVertical()
    {
        Vector3 directionUp = transform.up * Input.GetAxis("Vertical");

        //Debug.Log("movingVertical : " + movingVertical);

        if (movingVertical)
        {
            //return;
        }
        else
        {
            //Debug.Log("Y : " + directionUp.y + "\nisCanMoveUp : " + isCanMoveUp + "; isCanMoveDown : " + isCanMoveDown);

            if (directionUp.y >= 0 && !isCanMoveUp)
            {
                //Debug.Log("LookUp");

                animator.Play("LookUp");
                return;
            }

            if (directionUp.y < 0 && !isCanMoveDown)
            {
                //Debug.Log("LookDown");

                animator.Play("LookDown");
                return;
            }
            //return;
        }

        GetComponent<Rigidbody2D>().isKinematic = true;

        //GetComponent<Rigidbody2D>().isKinematic = true;
        movingVertical = true;

        Vector3 direction = transform.right * dirHoriz;

        if (directionUp.y > 0)
        {
            transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position
                + kDown * direction
                + directionUp,
            WalkSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position
                + kDown * direction
                + kUp * directionUp,
            WalkSpeed * Time.deltaTime);
        }
        /*
        transform.position = Vector3.MoveTowards(
            transform.position, 
            transform.position 
                + kDown * direction 
                + kUp * directionUp, 
            WalkSpeed * Time.deltaTime);
        */

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

    private void MoveUp()
    {
        if (!isCanMoveUp && moveState == MoveState.Idle)
        {
            animator.Play("LookUp");            
        }
    }

    private void MoveDown()
    {
        if (!isCanMoveDown && moveState == MoveState.Idle)
        {
            animator.Play("LookDown");
        }
    }

    private void MoveScript()
    {
        animator.Play("Walk");        
    }

    public void GetDamage(float damagePoint)
    {
        Lives -= damagePoint;

        if (Lives < 1)
        {
            Death();
        }
    }

    public void ChangeCanMoveUp()
    {
        isCanMoveUp = !isCanMoveUp;
    }

    public void ChangeCanMoveDown()
    {
        isCanMoveDown = !isCanMoveDown;
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

    public void ChangeMoveVertival()
    {

    }
}
