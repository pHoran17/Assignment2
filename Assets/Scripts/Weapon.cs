using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ShotControl shot;
    public bool isShooting;
    public Transform shotSpawn;
    public float shotSpeed;
    public float shotDelay;
    private float shotCounter;

    // Use this for initialization
    void Start()
    {


    }
	// Update is called once per frame
	void Update ()
    {
        if (isShooting)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = shotDelay;
                ShotControl newShot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as ShotControl;
                newShot.speed = shotSpeed;
                newShot.GetComponent<AudioSource>().Play();

            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
