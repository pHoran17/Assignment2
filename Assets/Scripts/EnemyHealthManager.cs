using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int health;
    public int currentHealth;
    public EnemyController ec;
    // Use this for initialization
    void Start ()
    {
        ec = GetComponent<EnemyController>();
        if(ec.enemyType == 0)
        {
            health = 1;
        }
        if(ec.enemyType == 3)
        {
            health = 1;
        }
        currentHealth = health;
	}
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }

    // Update is called once per frame
    void Update ()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
