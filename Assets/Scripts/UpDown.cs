using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    private Rigidbody2D rb2D;

    public float timer = 0;

    public bool addForce;
    public int forceCount;
    public float forceMultiplier;

    private Vector2 direction;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        direction = new Vector2(Random.Range(1, 10), Random.Range(1, 10));
    }

    void Update()
    {
        if (transform.position.y < -30)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (addForce)
        {
            transform.Translate(direction * Time.deltaTime * forceMultiplier);
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * forceMultiplier * Time.deltaTime;
            }
        }
    }

    public void Move()
    {
        rb2D.gravityScale = 1f;
        addForce = true;
    }
}
