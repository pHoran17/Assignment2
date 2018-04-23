using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour {

    public float speed;
    public int shotDamage;
    public int scoreValue;
    public GameController gc;
    // Use this for initialization
	void Start ()
    {
        gc = GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Astroid")
        {
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(shotDamage);
            gc.AddScore(scoreValue);
            Destroy(gameObject);
        }
        /*if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayControl>().hurtPlayer(shotDamage);
            Destroy(gameObject);
        }
        */
    }
}
