using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour {

    public float speed;
    public int shotDamage;
    // Use this for initialization
	void Start () {
		
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
            other.gameObject.GetComponent<EnemyController>().HurtEnemy(shotDamage);
            Destroy(gameObject);
        }
    }
}
