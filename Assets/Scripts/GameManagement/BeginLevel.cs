using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginLevel : MonoBehaviour
{
    private Creator creator;

    void Start()
    {
        creator = GameObject.FindGameObjectWithTag("Creator").GetComponent<Creator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            creator.onTheMove = true;
            creator.StartThisShit();
            print("BeginLevel");
            Destroy(gameObject);
        }
    }
}
