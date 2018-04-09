using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigSound : MonoBehaviour {
	private AudioSource aSource;
//	public AudioClip longOink;
//	public float longTimer = 28.0f;
	//public AudioClip shortOink;
	public float shortTimer = 3.0f;

	// Use this for initialization
	void Start () {
		aSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
//		if (longTimer > 0) {
//			longTimer -= Time.deltaTime;
//		} 
//		else {
//			AudioSource aSource = new AudioSource ();
//			aSource.clip = longOink;
//			aSource.Play ();
//			longTimer = 28.0f;
//		}
		if (shortTimer > 0) {
			shortTimer -= Time.deltaTime;
		} 
		else {
//			AudioSource aSource = new AudioSource ();
//			aSource.clip = shortOink;
//			aSource.Play ();
//			Debug.Log ("oink");
			aSource.Play();
			shortTimer = 10.0f;
		}
	}
}
