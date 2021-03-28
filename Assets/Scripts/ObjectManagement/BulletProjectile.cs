using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    public float movementSpeed;
    public bool movingRight;

    public Sprite leftBullet;
    public Sprite rightBullet;

    private SpriteRenderer sRenderer;

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        if (movingRight)
        {
            sRenderer.sprite = rightBullet;
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x + 100, transform.position.y), movementSpeed * Time.deltaTime);
        } else
        {
            sRenderer.sprite = leftBullet;
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x - 100, transform.position.y), movementSpeed * Time.deltaTime);
        }
    }
}
