using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody rb;
    private float speed = 2;
    public float moveSpeed;
    public PlayControl player;
    public int enemyType;
   
    //public float maxDist, minDist;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayControl>();
        if (enemyType == 1)
        {
            rb.velocity = new Vector3(Random.Range(-4, 3), 0, Random.Range(-8, 2)) * moveSpeed;
        }
    }
    private void FixedUpdate()
    {

        if(enemyType == 0)//for seeker enemies just move forward with rotation
        {
            rb.velocity = (transform.forward * moveSpeed);
        }
        if(enemyType == 1)//For Bystander enemies, wanders through level
        {
            //rb.velocity = new Vector3(Random.Range(-8,8),0,Random.Range(-4,4)) * moveSpeed;
        }
        if(enemyType == 2)//For defender enemies, avoids player
        {
            rb.velocity = -(transform.forward * moveSpeed);
        }
        //rb.velocity = (transform.forward * moveSpeed);
       
       // transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), Time.deltaTime);
        /*if (Vector3.Distance(transform.position, player.transform.position) >= minDist)
        {
            //Enemy needs to be rotated on Y axis so it will move towards player properly
            //transform.position = player.transform.position - transform.position;
            var delta = player.transform.position - transform.position;
            delta.Normalize();
            moveSpeed = speed * Time.deltaTime;
             transform.position = transform.position + rb.velocity;
            
        }
        */
    }
    // Update is called once per frame
    void Update ()
    {
       if(enemyType == 0)
        {
            Vector3 lookAt = player.transform.position - transform.position;
            lookAt.y = 0;
            var rotation = Quaternion.LookRotation(lookAt);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
            //transform.LookAt(lookAt);
        }
       if(enemyType == 1)
        {

        }




    }
}
