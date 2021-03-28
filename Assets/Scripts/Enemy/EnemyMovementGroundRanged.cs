using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementGroundRanged : MonoBehaviour
{
    public bool facingLeft;
    public bool isMoving;
    public float movementSpeed;

    private GameObject player;

    private Animator anim;

    private Rigidbody2D rb2D;
    public float fallMultiplier;
    public bool isGrounded;

    private void Start()
    {
        isMoving = true;
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        GravityMultiplier();
        HorizontalMovement();
    }

    void HorizontalMovement()
    {
        // Horizontal Lines
        Debug.DrawLine(new Vector2(transform.position.x - 0.26f, transform.position.y), new Vector2(transform.position.x - 0.66f, transform.position.y));
        Debug.DrawLine(new Vector2(transform.position.x + 0.26f, transform.position.y), new Vector2(transform.position.x + 0.66f, transform.position.y));

        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - 0.26f, transform.position.y), Vector2.left, 0.4f); // LEFT
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + 0.26f, transform.position.y), Vector2.right, 0.4f); // RIGHT
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance > 3)
        {
            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 0);
                facingLeft = true;
                if (hitLeft)
                {
                    isMoving = false;
                }
                else
                {
                    isMoving = true;
                }
            }
            else
            {

                transform.localScale = new Vector3(-1, 1, 0);
                if (!hitRight)
                {
                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                }
            }
        }
        else
        {
            isMoving = false;
            anim.SetBool("WalkBool", false);
        }

        if (isMoving)
        {
            if (!anim.GetBool("WalkBool"))
            {
                anim.SetBool("WalkBool", true);
            }
            if (facingLeft)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - 1, transform.position.y), movementSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 1, transform.position.y), movementSpeed * Time.deltaTime);
            }
        }
    }

    void GravityMultiplier()
    {
        if (!isGrounded && rb2D.velocity.y < 0)
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }
    }
}

