using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float startWait;
    public float spawnWait;
    public GameObject hazard;
    public GameObject enemyShip;
    //public GameObject[] enemies;
    public EnemyController enemyController;
    public Vector3 spawnValues;

	void Start ()
    {
        StartCoroutine(spawnWaves()); 
	}

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            Vector3 astSpawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            //Need to randomly spawn different ships with relevant behaviours
            Quaternion spawnRotation = new Quaternion();
            enemyController.enemyType = Random.Range(0, 2);
            //int i = enemyController.enemyType;
            Vector3 enemySpawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(enemyShip, enemySpawnPos, spawnRotation);
            Instantiate(hazard, astSpawnPos, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }
        /*Vector3 astSpawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        //Need to randomly spawn different ships with relevant behaviours
        Quaternion spawnRotation = new Quaternion();
        enemyController.enemyType = Random.Range(0, 2);
        int i = enemyController.enemyType;
        Vector3 enemySpawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
        Instantiate(enemies[i], enemySpawnPos, spawnRotation);
        */
        /*while (enemyController.enemyType != 3) //when game ends enemytype = 3 to end loop       
        {
            enemyController.enemyType = Random.Range(0, 2);
            int i = enemyController.enemyType;
            Vector3 enemySpawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(enemies[i], enemySpawnPos, spawnRotation);
        }*/


        //Instantiate(hazard, astSpawnPos, spawnRotation);
        
    }
	
}
