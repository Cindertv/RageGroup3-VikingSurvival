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
    float delay = 5f;
    float decay = 0.05f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {

        StartCoroutine(Spawner());
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
    IEnumerator Spawner()
    {
        do
        {
            Spawn() ;
            yield return new WaitForSecondsRealtime(delay);
            delay -= decay;
            delay = Mathf.Clamp(delay, 0.1f,float.MaxValue);
        } while (true);
    }
}
