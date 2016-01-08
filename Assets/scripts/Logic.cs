using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{

    public int score = 0;
    public int asteroids;
    public Text scoreText;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject enemySpawn;
    public GameObject[] asteroidPrefabs;
    public GameObject[] spawnPoints;
    public static Logic instance = null;
    private int currentAsteroids;
    private bool isDead;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        Setup();
    }

    public void Setup()
    {
        isDead = false;
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        Instantiate(enemyPrefab, enemySpawn.transform.position, Quaternion.identity);
        for (int i = 0; i < asteroids; i++ )
        {
            GameObject nextAsteroid = asteroidPrefabs[Random.Range(0, 2)];
            GameObject nextPos = spawnPoints[i];
            Instantiate(nextAsteroid, nextPos.transform.position, Quaternion.identity);
            currentAsteroids++;
        }
    }

    void CheckGameOver()
    {
        
        if (currentAsteroids < 1)
        {
            //You won!
           
            ResetLevel();
        }
        if (isDead)
        {
            //Game Over!
            ResetLevel();
        }
    }

    void ResetLevel()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void DestroyAsteroid()
    {
        currentAsteroids--;
        CheckGameOver();
    }

    public void AddScore(int points)
    {
        score = score + points;
        scoreText.text = "SCORE: " + score;
    }

    public void Die()
    {
        isDead = true;
        ResetLevel();
    }

    public void addAsteroid()
    {
        currentAsteroids++;
    }
   
    void Update()
    {
         
    }
   
}
