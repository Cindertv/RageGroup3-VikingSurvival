using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    NavMeshAgent agent;
    public PlayerController player;
    public int enemyHealth = 100;
    public GameObject healthPackPrefab;
    public Transform healthPackSpawnPoint;
    public Image uiEnemyHeatlh;
    public GameObject healthBoxPrefab;
    public Transform healthSpawnPoint;
    public float enemyDamage;
    void Start()
    {
        uiEnemyHeatlh.fillAmount = 1f;
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerController>();
        UpdateUI();
    }

    void Update()
    { 
        agent.SetDestination(player.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        BulletAttack bullet = other.GetComponent<BulletAttack>();
        if (bullet != null)
        {
            enemyHealth -= bullet.bulletDamage;
            UpdateUI();
            if (enemyHealth <= 0)
            {
                Destroy(this.gameObject);
                if (Random.value < 1)
                {
                    Instantiate(healthPackPrefab, healthPackSpawnPoint.position, healthPackSpawnPoint.rotation);
                }
                Instantiate(healthBoxPrefab, healthSpawnPoint.position, healthSpawnPoint.rotation);
            }
            Destroy(other.gameObject);
            

        }
    }

    private void UpdateUI()
    {
        uiEnemyHeatlh.fillAmount = enemyHealth / 100f;
    }
}

