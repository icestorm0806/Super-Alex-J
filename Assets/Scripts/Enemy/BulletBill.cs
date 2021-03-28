using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBill : MonoBehaviour
{
    private readonly Rigidbody2D rb2D;

    public void TakeDamage()
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
