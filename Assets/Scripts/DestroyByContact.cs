﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public int lifetime;
    public GameObject explosion;
    public GameObject pExplosion;
    public GameObject eExplosion;
    private GameController gameController;
    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
    void OnTriggerEnter(Collider other)
     {
        if(other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion,transform.position,transform.rotation);
        if(other.tag == "Player")
        {
            Instantiate(pExplosion,other.transform.position,other.transform.rotation);
            gameController.GameOver();
        }
        if (other.tag == "Enemy")
        {
            Instantiate(eExplosion, other.transform.position, other.transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);

     }
}
