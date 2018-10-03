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
<<<<<<< HEAD
    public GameObject healthPackPrefab;
    public Transform healthPackSpawnPoint;
    public Image uiEnemyHeatlh;
=======
    public GameObject healthBoxPrefab;
    public Transform healthSpawnPoint;
>>>>>>> 4f3bb261e254f7ecc592e6e1f4401939eeb6e3a2

    // Use this for initialization
    void Start()
    {
        uiEnemyHeatlh.fillAmount = 1f;
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerController>();
        UpdateUI();
    }

    // Update is called once per frame
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
<<<<<<< HEAD
                if (Random.value < 1)
                {
                    Instantiate(healthPackPrefab, healthPackSpawnPoint.position, healthPackSpawnPoint.rotation);
                }
=======
                Instantiate(healthBoxPrefab, healthSpawnPoint.position, healthSpawnPoint.rotation);
>>>>>>> 4f3bb261e254f7ecc592e6e1f4401939eeb6e3a2
            }
            Destroy(other.gameObject);

        }
    }

    private void UpdateUI()
    {
        uiEnemyHeatlh.fillAmount = enemyHealth / 100f;
    }
}

