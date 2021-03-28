using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaTurtle : EnemyHealth
{

    void TakeDamage()
    {
        switch (health)
        {
            case 0:
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
