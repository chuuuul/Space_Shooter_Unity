using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazard;
    public Vector3 spawnValue;
    public int hazardCount=10;

    public float spawnWait = 0.5f;
    public float spawnstart = 1.0f;
    public float waveWait = 4.0f;

    public Text scoreText;
    public Text gameOverText;
    public Text restartGameText;

    private int score = 0;
    private bool gameOverFlag;
    private bool restartFlag;


    void ScoreUpdate()
    {
        scoreText.GetComponent<Text>().text = "Score : " + score;
    }

    public void AddScore(int add)
    {
        score = score + add;
        ScoreUpdate();
    }

    public void GameOver()
    {
        gameOverFlag = true;
        gameOverText.GetComponent<Text>().text = "Game Over!";
    }

    void Start ()
    {
        ScoreUpdate();
        StartCoroutine (SpawnWave());
        restartGameText.GetComponent<Text>().text = "";
        gameOverText.GetComponent<Text>().text = "";
        gameOverFlag = false;
        restartFlag = false;

    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R) == true )
        {
            SceneManager.LoadScene(0);
        }

    }

    
    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(spawnstart);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity ;
                Instantiate(hazard[Random.Range(0, hazard.Length)], spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            if (gameOverFlag == true)
            {
                restartGameText.GetComponent<Text>().text = "Press 'R' for Restart";
                restartFlag = true;
                break;
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

}
