using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyFireBulletBill : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fireLeft;
    public GameObject fireRight;

    public float fireFrequencyMin;
    public float fireFrequencyMax;

    private float timer;

    private float rand;

    private GameObject player;
    private BulletProjectile projectileScript;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rand = UnityEngine.Random.Range(fireFrequencyMin, fireFrequencyMax + 1);
    }

    void Update()
    {
        timer += Time.deltaTime;
        TimeToFire();
    }

    void FireProjectile()
    {
        Vector3 fireLocation;
        if (player.transform.position.x < transform.position.x)
        {
            fireLocation = fireLeft.transform.position;
            GameObject projectile = Instantiate(bullet, fireLocation, quaternion.identity);
            projectileScript = projectile.GetComponent<BulletProjectile>();
            projectileScript.movingRight = false;
        }
        else
        {
            fireLocation = fireRight.transform.position;
            GameObject projectile = Instantiate(bullet, fireLocation, quaternion.identity);
            projectileScript = projectile.GetComponent<BulletProjectile>();
            projectileScript.movingRight = true;
        }

    }

    void TimeToFire()
    {
        if (timer > rand)
        {
            FireProjectile();
            timer = 0;
            rand = UnityEngine.Random.Range(fireFrequencyMin, fireFrequencyMax + 1);
        }
    }
}