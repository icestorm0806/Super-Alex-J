using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TempScript : MonoBehaviour
{

    public GameObject moreObjects;


    void Start()
    {
        for (int i = 1; i <= 11; i++)
        {
            Instantiate(moreObjects, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - i), quaternion.identity);
        }
    }
}
