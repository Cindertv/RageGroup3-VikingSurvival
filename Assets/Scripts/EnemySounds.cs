using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour {

    
    public AudioClip attack;

    public AudioSource enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StrikeSound ()
    {
        enemy.PlayOneShot(attack);
    }

    
}
