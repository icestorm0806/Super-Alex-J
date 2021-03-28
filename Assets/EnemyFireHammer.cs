using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyFireHammer : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb2D;
    public GameObject projectile;
    public GameObject projectileSpawnLocation;

    public float fireDistance;

    public float projectileSpeed;
    public float fireFrequency;
    private float timer;

    private EnemyMovement enemyMovement;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (RangeCheck(gameObject.transform.position, player.transform.position, fireDistance))
        {
            timer += Time.deltaTime;
            if (!enemyMovement.facingRight && timer >= fireFrequency)
            {
                SpawnProjectile(new Vector2(-10, 10));
                timer = 0;
            }
            else if (enemyMovement.facingRight && timer >= fireFrequency)
            {
                SpawnProjectile(new Vector2(10, 10));
                timer = 0;
            }
            if (player.transform.position.x < transform.position.x)
            {
                enemyMovement.facingRight = false;
            }
            else
            {
                enemyMovement.facingRight = true;
            }
        }
    }

    void SpawnProjectile(Vector2 direction)
    {
        GameObject spawnedProjectile = Instantiate(projectile, new Vector3(projectileSpawnLocation.transform.position.x, projectileSpawnLocation.transform.position.y, 0), quaternion.identity);
        rb2D = spawnedProjectile.GetComponent<Rigidbody2D>();
        rb2D.AddForce(direction * projectileSpeed, ForceMode2D.Force);
    }

    bool RangeCheck(Vector3 selfie, Vector3 other, float range)
    {
        float distance = Vector3.Distance(other, selfie);
        bool inRange;
        if (distance < range)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
        return inRange;
    }
}
