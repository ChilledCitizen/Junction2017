using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fence")
        {
            Physics.IgnoreCollision(GetComponent<BoxCollider>(), collision.gameObject.GetComponent<BoxCollider>());
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Fence")
        {
            Physics.IgnoreCollision(GetComponent<BoxCollider>(), collision.gameObject.GetComponent<BoxCollider>());
        }
    }

}
