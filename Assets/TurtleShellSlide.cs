using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleShellSlide : MonoBehaviour
{
    public float slideSpeed;

    public bool isMoving;
    public bool facingRight;
    private GameObject player;

    private void Start()
    {
        isMoving = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        HorizontalMovement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerHitter"))
        {
            if (isMoving)
            {
                isMoving = false;
            }
            else
            {
                isMoving = true;
            }

            if(player.transform.position.x > transform.position.x)
            {
                facingRight = true;
            } else
            {
                facingRight = false;
            }

        }
    }

    void HorizontalMovement()
    {
        if (isMoving)
        {
            if (facingRight)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 1, transform.position.y), slideSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - 1, transform.position.y), slideSpeed * Time.deltaTime);
            }
        }
    }

}
