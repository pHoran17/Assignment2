using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Shot shot;
    public float speed;
    
    // Use this for initialization
    void Start ()
    {
       
        shot.speed = speed;

    }
	public void Fire()
    {
        Instantiate(shot, transform.position, transform.rotation);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
