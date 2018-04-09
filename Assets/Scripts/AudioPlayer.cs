using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

	private int triggerCount = 0;
	private AudioSource audio;

	void OnTriggerEnter( Collider collider ) {
		AudioSource aSource = collider.gameObject.GetComponent<AudioSource>();

		if( aSource != null ) {
			aSource.Play ();
			triggerCount++;
		}
	}

	void OnTriggerExit( Collider collider ) {
		AudioSource aSource = collider.gameObject.GetComponent<AudioSource>();

		if( aSource != null ) {
			triggerCount--;
			if( triggerCount <= 0 ) {
				aSource.Stop();
			}
		}
	}
}
