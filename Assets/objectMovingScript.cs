using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMovingScript : MonoBehaviour {

	private Rigidbody rBody;
	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Alpha3)) {
			rBody.constraints = RigidbodyConstraints.None;
			print ("Unfreeze");
		}
	}
}
