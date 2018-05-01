using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateScript : MonoBehaviour {
	Vector3 initialPos;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		print("other: " + other.collider.tag);
		print("initPos: " + initialPos);
		if (other.collider.tag == "Magma")
		{
			transform.position = initialPos;
		}
        if (other.collider.tag != "Floor" || other.collider.tag != "Wall")
        {
            rb.isKinematic = true;
        }
        if (other.collider.tag == "Player-Push" || other.collider.tag == "Switch Box")
        {
            rb.isKinematic = false;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.collider.tag == "Player-Push" || other.collider.tag == "Switch Box")
        {
            rb.isKinematic = false;
        }
    }
}
