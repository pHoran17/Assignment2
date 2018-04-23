using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {

    //public EnemyController enemyShot;
    public EnemyShotControl enemyShot;
    public bool isShooting;
    public Transform shotSpawn;
    public float shotSpeed;
    public float shotDelay;
    private float shotCounter;

    // Use this for initialization
    void Start()
    {
        isShooting = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = shotDelay;
                //EnemyController newShot = Instantiate(enemyShot, shotSpawn.position, shotSpawn.rotation) as EnemyController;
                EnemyShotControl newShot = Instantiate(enemyShot, shotSpawn.position, shotSpawn.rotation) as EnemyShotControl;
                newShot.speed = shotSpeed;

            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
