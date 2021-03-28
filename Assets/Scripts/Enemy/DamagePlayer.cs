using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;
    private float timer;
    public bool timerActive;
    public GameObject hitBox;

    public GameObject damageEnemyTrigger;

    private Collider2D circleCollider;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();

        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        HitTimer();
        if (!playerMovement.isGrounded)
        {
            circleCollider.enabled = false;
        }
        else
        {
            circleCollider.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!timerActive)
        {
            if (other.CompareTag("PlayerHitBox"))
            {
                timerActive = true;
                hitBox.SetActive(false);
                playerHealth.DamagePlayer();
            }
        }
    }

    void HitTimer()
    {
        if (timerActive)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                hitBox.SetActive(true);
                timerActive = false;
            }
        }
    }
}
