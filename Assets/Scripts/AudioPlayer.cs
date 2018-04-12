using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

	private int triggerCount = 0;

	void OnTriggerEnter( Collider collider ) {
		AudioSource aSource = collider.gameObject.GetComponent<AudioSource>();

		if( aSource != null ) {
			Debug.Log ("collided, should make sound");
			aSource.Play ();
			triggerCount++;
		}
	}

	void OnTriggerExit( Collider collider ) {
		AudioSource aSource = collider.gameObject.GetComponent<AudioSource>();

		if( aSource != null && collider.gameObject.name != "Magma") {
			print (collider.gameObject.name);
			triggerCount--;
			if( triggerCount <= 0 ) {
				aSource.Stop();
			}
		}
	}
}
