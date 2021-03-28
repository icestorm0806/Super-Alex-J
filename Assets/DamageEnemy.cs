using GameFlow;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public List<GameObject> damagePlayerList;
    private float timer;
    private bool isDamaged;

    public GameObject damagedEnemy;

    public GameObject objectParent;

    void Start()
    {
        isDamaged = false;
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        TookDamage();
    }
     
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerHitBox"))
        {
            Instantiate(damagedEnemy, new Vector2(transform.position.x, transform.position.y - 0.45f), quaternion.identity);
            print("enemy hit");
            isDamaged = true;
            playerMovement.DamageJump();
            Destroy(objectParent);
        }
    }

    void TookDamage()
    {
        if (isDamaged)
        {
            foreach (GameObject gO in damagePlayerList)
            {
                gO.SetActive(false);
            }
            timer += Time.deltaTime;
            if (timer > 2)
            {
                isDamaged = false;
            }
        }
        else
        {
            timer = 0;
            foreach (GameObject gO in damagePlayerList)
            {
                gO.SetActive(true);
            }
        }
    }
}
