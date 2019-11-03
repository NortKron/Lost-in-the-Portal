using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player0 : MonoBehaviour
{
    public int Lives = 10; 
    public float WalkSpeed = 1.0f;
    public float JumpForce = 2.0f;

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
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        else if (Input.GetButton("Horizontal"))
        {
            Walk();
        }
        else
        {
            Idle();
        }
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
}
