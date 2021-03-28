using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Debugging : MonoBehaviour
{
    public GameObject centerLineStart;
    public GameObject centerLineEnd;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void MaintainGroundedHeight()
    {
        // Line one
        Vector2 startingPos = new Vector2(transform.position.x, transform.position.y - 20.49f);
        Vector2 endingPos = new Vector2(transform.position.x, transform.position.y - 30.49f);

        Debug.DrawLine(startingPos, endingPos, Color.green, 0.0f); // LEFT
        RaycastHit2D centerHit = Physics2D.Raycast(startingPos, Vector2.down, 10); // LEFT

        if (centerHit)
        {
            transform.position = new Vector2(transform.position.x, centerHit.point.y + 22);
        }
    }

    private double angleCalculator(Vector2 leftPoint, Vector2 rightPoint)
    {
        double angle = Math.Atan2(rightPoint.y - leftPoint.y, rightPoint.x - leftPoint.x);
        double angleDegrees = (180 / Mathf.PI) * angle;
        return angleDegrees;
    }
}


/* private double GroundAngle()
{
    // Line one
    Vector2 startingPos1 = new Vector2(transform.position.x - 8.5f, transform.position.y - 20.49f);
    Vector2 endingPos1 = new Vector2(transform.position.x - 8.5f, transform.position.y - 32.49f);

    // Line two
    Vector2 startingPos2 = new Vector2(transform.position.x + 8.5f, transform.position.y - 20.49f);
    Vector2 endingPos2 = new Vector2(transform.position.x + 8.5f, transform.position.y - 32.49f);

    Debug.DrawLine(startingPos1, endingPos1, Color.blue, 0.0f); // LEFT
    Debug.DrawLine(startingPos2, endingPos2, Color.blue, 0.0f); // RIGHT


   hitLeftSide = Physics2D.Raycast(startingPos1, Vector2.down, 12); // LEFT
   hitRightSide = Physics2D.Raycast(startingPos2, Vector2.down, 12); // RIGHT


    if (hitLeftSide)
    {
        angleCheckLeft.transform.position = hitLeftSide.point;
    }
    if (hitRightSide)
    {
        angleCheckRight.transform.position = hitRightSide.point;
    }
    if(!hitLeftSide && !hitRightSide)
    {
        isGrounded = false;
    } else
    {
        isGrounded = true;
    }

    return Math.Round(angleCalculator(hitLeftSide.point, hitRightSide.point));
}
*/