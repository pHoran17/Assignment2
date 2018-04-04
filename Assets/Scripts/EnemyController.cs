using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody rb;
    private float speed = 2;
    public float moveSpeed;
    public PlayControl player;
    public float maxDist, minDist;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayControl>();
	}
    private void FixedUpdate()
    {

        
        rb.velocity = (transform.forward * moveSpeed);
        if (Vector3.Distance(transform.position, player.transform.position) >= minDist)
        {
            //Enemy needs to be rotated on Y axis so it will move towards player properly
            //transform.position = player.transform.position - transform.position;
            var delta = player.transform.position - transform.position;
            delta.Normalize();
            moveSpeed = speed * Time.deltaTime;
            transform.position = transform.position + rb.velocity;
        }
    }
    // Update is called once per frame
    void Update ()
    {
        transform.LookAt(player.transform.position);
        
	}
}
