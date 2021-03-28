using GameFlow;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ThrowHammer : MonoBehaviour
{
    private GameObject player;

    public GameObject hammer;
    public float hammerStrength;
    private Rigidbody2D rb2D;

    private Vector3 difference;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        difference = player.transform.position - transform.position;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (difference.x < 10)
            {
                GameObject spawnedObject = Instantiate(hammer, transform.position, quaternion.identity);
                rb2D = spawnedObject.GetComponent<Rigidbody2D>();
                rb2D.AddForce(new Vector2(10, 10) * hammerStrength, ForceMode2D.Force);
            }
        }
    }
}
