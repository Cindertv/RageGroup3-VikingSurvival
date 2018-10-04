using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    public float timeToattack = 3f;
    private float attackdelay = 0f;
    public float attackdamage = 4f;
    public float factor = 0.1f;
    public Animator anim;
    private void Start()
    {
        // anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerStay(Collider player)
    {
        attackdelay -= Time.deltaTime;

        if (player.CompareTag("Player"))
        {
            if (attackdelay <= 0)
            {
                float multiplier = (int)(Time.timeSinceLevelLoad / 20f) + 1;
                player.GetComponent<PlayerController>().TakeDamage(attackdamage * multiplier * factor);
                print("Player getting attacked" + (attackdamage * multiplier * factor));
                anim.SetTrigger("Attack");
                attackdelay = timeToattack;
            }
        }
    }
}
