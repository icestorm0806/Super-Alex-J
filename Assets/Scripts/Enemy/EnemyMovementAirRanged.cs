using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAirRanged : MonoBehaviour
{
    public bool movingRight;
    public float movementSpeed;

    private Animator anim;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        anim.SetBool("WalkingBool", true);
        if (player.transform.position.x < transform.position.x)
            movingRight = false;
        else
            movingRight = true;
    }

    private void Update()
    {
        HorizontalMovement();
    }

    public virtual void HorizontalMovement()
    {
        if (movingRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 1, transform.position.y), movementSpeed * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - 1, transform.position.y), movementSpeed * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 0);
        }
    }
}
