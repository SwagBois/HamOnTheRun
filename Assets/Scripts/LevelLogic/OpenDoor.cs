using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public GameObject door;

    Animator doorAnim, switchAnim;

	// Use this for initialization
	void Start () {
        doorAnim = door.GetComponent<Animator>();
        switchAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            doorAnim.SetBool("open", true);
            switchAnim.SetBool("on", true);
        }
    }

}
