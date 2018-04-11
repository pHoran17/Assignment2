using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    // Use this for initialization
    public float tumble;
	void Start ()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;	
	}
}
