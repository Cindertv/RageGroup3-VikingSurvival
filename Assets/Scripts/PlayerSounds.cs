using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour {

    public AudioClip footsteps;
    public AudioClip attack;

    public AudioSource player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void WalkSound ()
    {
        player.PlayOneShot(footsteps);
    }

    
}
