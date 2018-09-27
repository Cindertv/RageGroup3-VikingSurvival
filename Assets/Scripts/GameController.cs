using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController Instance;

    public GameObject enemyPrefab;
    public float radius = 10;

    public Text scoreText;
    public int score = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {

        InvokeRepeating("Spawn", 0, 3);
        UpdateScore();

    }

    void Spawn()
    {
        Vector3 spawnPoint = Random.insideUnitSphere * radius;
        spawnPoint.y = 0; 

        Instantiate(enemyPrefab, transform.position + spawnPoint, Quaternion.identity);
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore()
    {
        score++;
        UpdateScore();
    }
}
