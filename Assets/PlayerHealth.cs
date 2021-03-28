using GameFlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void DamagePlayer()
    {
        Debug.Log("Player takes damage");
        playerHealth--;
        if (playerHealth <= 0)
        {
            PlayerDies();
        }
        else
        {
            InvincibilityFlash();
        }
    }

    private void PlayerDies()
    {
        SceneManager.LoadScene("BattleGround");
        Debug.Log("Player dies");
    }

    private void InvincibilityFlash()
    {
        anim.SetTrigger("playInvincibility");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            DamagePlayer();
        }
    }
}
