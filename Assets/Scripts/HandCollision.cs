using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollision : MonoBehaviour {


    public PlayerController playerController;
	// Use this for initialization
	void Start () {

        playerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            playerController.isFallen = true;
        }
    }
}
