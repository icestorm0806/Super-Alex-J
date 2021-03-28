using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float followSpeed;
    public float verticalHeight;
    void Update()
    {
        Vector3 newPosition = player.transform.position;
        newPosition.z = -10;
        newPosition.y += verticalHeight;
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
