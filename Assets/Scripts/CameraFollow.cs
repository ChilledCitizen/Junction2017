using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 location;
    public Vector3 cameraLocationOffset;

	// Use this for initialization
	void Start () {

        player = GameObject.FindWithTag("Player");
        this.transform.rotation = Quaternion.Euler(20, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {

        if (!player)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (player)
        {
            location = player.transform.position;

            transform.position = location + cameraLocationOffset;
        }
       

       

		
	}
}
