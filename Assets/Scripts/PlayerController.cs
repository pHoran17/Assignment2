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

   
    private float fireRate;
    public float shotDelay;
    public Transform shotSpawner;
    

    // Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	private void Update ()
    {
        
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float rx = Input.GetAxis("Right_Horizontal");
        float ry = Input.GetAxis("Right_Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = new Vector3(3 * moveHorizontal, 0, 3 * moveVertical);//Fixes issue with player not rotating correctly
        //transform.Translate(moveHorizontal * Time.deltaTime * playerSpeed, 0, moveVertical * Time.deltaTime * playerSpeed);
        //rb.velocity = movement * speed;
        float angle = Mathf.Atan2(rx, ry);
        GetComponent<Transform>().eulerAngles = new Vector3(0, angle, 0);

        if ((rx > 0.2 || rx < -0.2) && (shotDelay == 0))
        {
            //shotDelay = Time.time + fireRate;
            shotDelay = 1;
            Instantiate(shotSpawner, transform.position, shotSpawner.rotation);
            StartCoroutine(delayReset());
        }
        if ((ry > 0.2 || ry < -0.2) && (shotDelay == 0))
        {
            //shotDelay = Time.time + fireRate;
            shotDelay = 1;
            Instantiate(shotSpawner, transform.position, shotSpawner.rotation);
            StartCoroutine(delayReset());
        }
        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z,boundary.zMin, boundary.zMax)
            );


        //Vector3 pDirection = Vector3.right * rx + Vector3.forward * ry;
        //GetComponent<Transform>().eulerAngles = pDirection;
        
    }
    IEnumerator delayReset()
    {
        yield return new WaitForSeconds(0.4f);
        shotDelay = 0;
    }
    
}
