using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BlackShellDormant : MonoBehaviour
{
    public float timer;
    public GameObject blackShell;

    void Start()
    {
        
    }

    void Update()
    {
        TurnBackIntoBlackShell();
    }

    void TurnBackIntoBlackShell()
    {
        timer += Time.deltaTime;

        if(timer >= 6)
        {
            Instantiate(blackShell, transform.position, quaternion.identity);
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerHitter"))
        {
            timer = 0;
        }
    }
}
