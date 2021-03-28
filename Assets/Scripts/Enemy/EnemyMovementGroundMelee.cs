using GameFlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementGroundMelee : MonoBehaviour
{
    public bool movingRight;
    public float movementSpeed;
    private Animator anim;
    private Rigidbody2D rb2D;
    public float fallMultiplier;
    public bool isGrounded;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        anim.SetBool("WalkingBool", true);

        if (player.transform.position.x < transform.position.x)
            movingRight = false;
        else
            movingRight = true;
    }


    private void Update()
    {
        GravityMultiplier();
        HorizontalMovement();
    }

    private void HorizontalMovement()
    {
        if (movingRight)
        {
            print("Moving Right!");
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 1, transform.position.y), movementSpeed * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else
        {
            print("Moving Left!");
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - 1, transform.position.y), movementSpeed * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 0);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            if (movingRight)
            {
                movingRight = false;
            }
            else
            {
                movingRight = true;
            }
        }
    }

    private void GravityMultiplier()
    {
        if (!isGrounded && rb2D.velocity.y < 0)
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }
    }
}
