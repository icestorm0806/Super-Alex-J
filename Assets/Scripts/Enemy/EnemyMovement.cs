using DG.Tweening;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool facingRight;
    public bool isMoving;
    public bool ranged;
    public float movementSpeed;

    private Animator anim;

    private Rigidbody2D rb2D;
    public float fallMultiplier;
    public bool isGrounded;

    private GameObject player;

    void Start()
    {
        print("hi");
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.x < transform.position.x)
            facingRight = false;
        else
            facingRight = true;

        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DetectSurroundingArea();
        GravityMultiplier();
        HorizontalMovement();
    }

    void DetectSurroundingArea()
    {
        Debug.DrawLine(new Vector2(transform.position.x - 0.26f, transform.position.y), new Vector2(transform.position.x - 0.46f, transform.position.y)); // LEFT
        Debug.DrawLine(new Vector2(transform.position.x + 0.26f, transform.position.y), new Vector2(transform.position.x + 0.46f, transform.position.y)); // RIGHT
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y - 0.26f), new Vector2(transform.position.x, transform.position.y - 0.46f)); // DOWN
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - 0.26f, transform.position.y), Vector2.left, 0.2f); // LEFT
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + 0.26f, transform.position.y), Vector2.right, 0.2f); // RIGHT
        RaycastHit2D hitDown = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.26f), Vector2.right, 0.2f); // DOWN

        if (hitLeft)
        {
            if (hitLeft.transform.CompareTag("Player"))
                return;
            facingRight = true;
        }

        if (hitRight)
        {
            if (hitRight.transform.CompareTag("Player"))
                return;
            facingRight = false;
        }

        /*
        if (hitDown)
        {
            if (hitDown.transform.CompareTag("Ground"))
            {

            }
        }*/
    }

    public virtual void HorizontalMovement()
    {
        if (isMoving)
        {
            anim.SetBool("WalkingBool", true);
            if (facingRight)
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
        else
        {
            if (anim != null)
                anim.SetBool("WalkingBool", false);
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
