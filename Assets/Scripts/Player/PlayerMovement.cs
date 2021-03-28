using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float velocity;
    private float moveInput;
    private float jumpTimeCounter;

    public LayerMask whatIsGround;
    public Transform groundCheck;

    public float movementSpeed;
    public float jumpTime;
    public float fallMultiplier;
    public float jumpForce;
    public float groundCheckRadius;
    public bool isGrounded;
    public bool isJumping;

    void Start()
    {
        velocity = 0;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (rb2D.velocity.y < velocity)
        {
            velocity = rb2D.velocity.y;
        }
        ControlledJump();
        GravityMultiplier();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb2D.velocity = new Vector2(movementSpeed * moveInput, rb2D.velocity.y);
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void ControlledJump()
    {
        if ((isGrounded && Input.GetButtonDown("Jump")))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb2D.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetButton("Jump"))
        {
            if (isJumping && jumpTimeCounter > 0)
            {
                rb2D.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
                if (Input.GetButtonUp("Jump"))
                {
                    jumpTimeCounter = 0;
                }
            }
        }
        else
        {
            isJumping = false;
        }
    }

    public void DamageJump()
    {
        rb2D.velocity = Vector2.up * jumpForce;
    }

    void GravityMultiplier()
    {
        if (!isGrounded && rb2D.velocity.y < 0)
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }
    }
}