using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float playerSpeed;
    public Boundary boundary;

    public Weapon weapon;
    //public GameObject shot;
    //public Transform shotSpawner;
    

    // Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	private void Update ()
    {
		if(Input.GetAxis("Right_Trigger") == 1)
        {
            weapon.Fire();

        }
	}
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(moveHorizontal * Time.deltaTime * playerSpeed, 0, moveVertical * Time.deltaTime * playerSpeed);
        //rb.velocity = movement * speed;
        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z,boundary.zMin, boundary.zMax)
            );
        float rx = Input.GetAxis("Right_Horizontal");
        float ry = Input.GetAxis("Right_Vertical");

        float angle = Mathf.Atan2(rx, ry);
        transform.rotation = Quaternion.EulerAngles(0, angle, 0);
    }
}
