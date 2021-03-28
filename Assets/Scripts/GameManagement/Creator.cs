using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Creator : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float movementSpeed;

    public Vector2 startPosition;
    public Vector2 nextPosition;

    public bool readyToMove;
    public bool onTheMove;
    public bool building;


    private void Start()
    {
        readyToMove = false;
        onTheMove = false;
        building = false;
        startPosition = transform.position;
    }

    void Update()
    {
        Moving();
    }

    public void StartThisShit()
    {
        nextPosition = new Vector2(2, 0);
        PlantObject();
        onTheMove = true;
    }

    public void Moving()
    {
            if (onTheMove)
                transform.position = Vector2.MoveTowards(transform.position, nextPosition, FindDifference() * Time.deltaTime);
            if (new Vector2(transform.position.x, transform.position.y) == nextPosition)
            {
                onTheMove = false;
                startPosition = nextPosition;
                //NextMove();
            }
    }
    /*
    void NextMove()
    {
        print("nextmove");
        int rand = UnityEngine.Random.Range(0, 4);
        rand = 1;
        switch (rand)
        {
            case 1:
                FlatLine();
                break;
            case 2:
                // stuff happens
                break;
            case 3:
                // stuff happens
                break;
            case 4:
                // stuff happens
                break;
            default:
                break;
        }
    }

    void FlatLine()
    {
        int length = UnityEngine.Random.Range(3, 5);
        int position = UnityEngine.Random.Range(0, 3);
        int count = 0;

        switch (position)
        {
            case 0:
                print("case 0");
                nextPosition = new Vector2(transform.localPosition.x + 1, transform.localPosition.y + 1);
                break;
            case 1:
                print("case 1");
                nextPosition = new Vector2(transform.localPosition.x + 1, transform.localPosition.y);
                break;
            case 2:
                print("case 2");
                nextPosition = new Vector2(transform.localPosition.x + 1, transform.localPosition.y - 1);
                break;
            default:
                break;
        }

        while (count < length)
        {
            if (readyToMove)
            {
                onTheMove = true;
                readyToMove = false;
            }
            else
            {

            }
        }

        for (int i = 0; i < length; i++)
        {
            readyToMove = true;
            nextPosition = new Vector2(transform.localPosition.x + 1, transform.localPosition.y);
            print("for loop");
            PlantObject();
        }
    }
    */
    private float FindDifference()
    {
        return Vector2.Distance(startPosition, nextPosition);
    }

    void PlantObject()
    {
        Instantiate(objectToSpawn, transform.position, quaternion.identity);
    }
}
