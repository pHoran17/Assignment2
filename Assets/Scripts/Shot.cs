using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public float speed;
    public float sRotate;
    Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        float rx = Input.GetAxis("Right_Horizontal");
        float ry = Input.GetAxis("Right_Vertical");
        rb = GetComponent<Rigidbody>();
        
        if (rx > 0.2)
        {
            rx = 5;
            sRotate = 90;
        }
        if (rx < -0.2)
        {
            rx = -5;
            sRotate = -90;
        }
        if (ry > 0.2)
        {
            ry = 5;
            sRotate = 180;
        }
        if (ry < -0.2)
        {
            ry = -5;
            sRotate = 0;
        }
        rb.velocity = new Vector3(rx, 0, ry);
        GetComponent<Transform>().eulerAngles = new Vector3(0, sRotate, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
