using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
	
	void Start ()
    {
        spawnWaves(); 
	}

    void spawnWaves()
    {
        Vector3 spawnPosition = new Vector3();
        Quaternion spawnRotation = new Quaternion();
        Instantiate(hazard, spawnPosition, spawnRotation);
    }
	
}
