using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenOutOfRange : MonoBehaviour
{
    private GameObject destroyer;

    void Update()
    {
        if (!destroyer)
        {
            destroyer = GameObject.FindGameObjectWithTag("Destroyer");
        }
        if (destroyer.transform.position.x >= transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
