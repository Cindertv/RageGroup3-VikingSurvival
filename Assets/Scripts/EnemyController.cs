using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    NavMeshAgent agent;
    public PlayerController player;
    public int enemyHealth = 100;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerController>();

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
            Debug.Log("I got hit by " + bullet.name);
            enemyHealth -= bullet.bulletDamage;
            if (enemyHealth <= 0)
            {
                Destroy(this.gameObject);
            }
            Destroy(other.gameObject);

        }
    }
}

