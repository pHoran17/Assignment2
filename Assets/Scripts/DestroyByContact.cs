using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public int lifetime;
    public int scoreValue;
    public GameObject explosion;
    public GameObject pExplosion;
    public GameObject eExplosion;
    private PlayControl pc;
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
        //pc.gameObject.GetComponent<Renderer>().enabled = true;
    }
    void OnTriggerEnter(Collider other)
     {
        if(other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(pExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            //pc.gameObject.GetComponent<Renderer>().enabled = false;
            //Object.DestroyObject(other.gameObject);
        }
        if (other.tag == "Enemy")
        {
            Instantiate(eExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
        
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);

     }
}
