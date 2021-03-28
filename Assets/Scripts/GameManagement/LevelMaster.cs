using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LevelMaster : MonoBehaviour
{
    public GameObject colliders;
    public GameObject blockPlaceHolder;

    public List<GameObject> connectedObjectsList;
    public List<Vector2> boundsList;

    private SpriteRenderer sRenderer;

    public Sprite sprite;

    public int spawnDistance;

    private GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        SpawnNewBlocks();
    }

    private void Connect()
    {
        PolygonCollider2D polyCollider = colliders.AddComponent<PolygonCollider2D>();
        int index = 0;
        foreach (GameObject block in connectedObjectsList)
        {
            sRenderer = block.GetComponent<SpriteRenderer>();
            boundsList.Add(new Vector2(sRenderer.sprite.bounds.min.x, sRenderer.sprite.bounds.min.y) + new Vector2(block.transform.position.x, block.transform.position.y));
            boundsList.Add(new Vector2(sRenderer.sprite.bounds.min.x, sRenderer.sprite.bounds.max.y) + new Vector2(block.transform.position.x, block.transform.position.y));
            boundsList.Add(new Vector2(sRenderer.sprite.bounds.max.x, sRenderer.sprite.bounds.max.y) + new Vector2(block.transform.position.x, block.transform.position.y));
            boundsList.Add(new Vector2(sRenderer.sprite.bounds.max.x, sRenderer.sprite.bounds.min.y) + new Vector2(block.transform.position.x, block.transform.position.y));
            polyCollider.SetPath(index, boundsList);
            index++;
            polyCollider.pathCount++;
            boundsList.Clear();
        }
        polyCollider.pathCount--;
    }

    void SpawnNewBlocks()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject block = Instantiate(blockPlaceHolder, new Vector2(player.transform.position.x + 2, player.transform.position.y + 2), quaternion.identity);
            GiveObjectSprite(block);
        }
    }

    void GiveObjectSprite(GameObject block)
    {
        sRenderer = block.GetComponent<SpriteRenderer>();
        sRenderer.sprite = sprite;

        PolygonCollider2D polyCollider = block.AddComponent<PolygonCollider2D>();
        boundsList.Add(new Vector2(sRenderer.sprite.bounds.min.x, sRenderer.sprite.bounds.min.y));
        boundsList.Add(new Vector2(sRenderer.sprite.bounds.min.x, sRenderer.sprite.bounds.max.y));
        boundsList.Add(new Vector2(sRenderer.sprite.bounds.max.x, sRenderer.sprite.bounds.max.y));
        boundsList.Add(new Vector2(sRenderer.sprite.bounds.max.x, sRenderer.sprite.bounds.min.y));
        polyCollider.SetPath(0, boundsList);
        boundsList.Clear();
    }
}