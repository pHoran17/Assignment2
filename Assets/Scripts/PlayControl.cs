using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayControl : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private Vector3 movement;
    private Vector3 moveVelocity;
    private float rx, ry;
    public Weapon weapon;
    public Transform shotSpawn;
    public Boundary boundary;


    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame(frame rate will vary)
	void Update ()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = movement * speed;
        Vector3 pDirection = Vector3.right * Input.GetAxisRaw("Right_Horizontal") + Vector3.forward * Input.GetAxisRaw("Right_Vertical");
        if(pDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(pDirection, Vector3.up);
            weapon.isShooting = true;
        }
        else if(pDirection.sqrMagnitude == 0) 
        {
            weapon.isShooting = false;
        }
        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        

    }
    //Occurs every 0.2 seconds
    private void FixedUpdate()
    {
        rb.velocity = moveVelocity;
        rx = Input.GetAxisRaw("Right_Horizontal");
        ry = Input.GetAxisRaw("Right_Vertical");
    }
}
