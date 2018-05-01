using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateScript : MonoBehaviour {
	Vector3 initialPos;
	// Use this for initialization
	void Start () {
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
	}
}
