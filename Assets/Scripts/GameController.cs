using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float startWait;
    public float spawnWait;
    public float waveWait;
    public GameObject hazard;
    public GameObject enemyShip;
    //public GameObject[] enemies;
    public EnemyController enemyController;
    public Vector3 spawnValues;
    public int spawnCount;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    private int score;

    private bool gameOver;
    private bool restart;

    void Start ()
    {
        score = 0;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        UpdateScore();
        StartCoroutine(spawnWaves()); 
	}

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for(int i = 0; i < spawnCount; i++)
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
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press Start to restart";
                restart = true;
                break;
            }
        }
        
    }
    private void Update()
    {
        if (restart)
        {
            if (Input.GetButtonDown("JoystickButton7"))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
