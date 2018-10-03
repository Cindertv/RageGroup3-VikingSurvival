using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatlhPickupController : MonoBehaviour {

    public PlayerController playerHealth;
    public float amountOfhealthPickupedup = 0.125f;

	void Start ()
    {
        amountOfhealthPickupedup = 0.125f;
        playerHealth = FindObjectOfType<PlayerController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        
        //if (playerHealth.playerHeatlh <= 100)
        {
            
            if (other.CompareTag("Player"))
            {
                playerHealth.playerHeatlh += amountOfhealthPickupedup;
                print("amountOfhealthPickupedup" + amountOfhealthPickupedup);
                Destroy(this.gameObject);          
            }
            
        }
    }

}
