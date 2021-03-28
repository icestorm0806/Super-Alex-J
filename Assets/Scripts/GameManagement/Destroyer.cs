using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float movementSpeed;
    public bool timeToMove;

    private GameObject creator;

    private void Start()
    {
        creator = GameObject.FindGameObjectWithTag("Creator");
    }

    void Update()
    {
        gameObject.transform.position = new Vector2(creator.transform.position.x - 20, creator.transform.position.y);
    }
}
