using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BlackShell : EnemyHealth
{

   // private EnemyMovement enemyMovement;
   // private Animator anim;

    public GameObject blackShellDormant;

    void Start()
    {
       // anim = GetComponent<Animator>();
        //enemyMovement = GetComponent<EnemyMovement>();
    }


    void TakeDamage()
    {
        health--;
        switch (health)
        {
            case 0:
                Instantiate(blackShellDormant, transform.position, quaternion.identity);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
