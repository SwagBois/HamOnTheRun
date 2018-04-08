using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour {

    public GameObject player;

    private float y_rot = 180;
    private float x_rot = 60;

    private Vector3 offset;
    private Vector3 zero_v;
	// Use this for initialization
	void Start ()
    {
        transform.rotation = Quaternion.FromToRotation(transform.position, zero_v);
        transform.Rotate(x_rot, y_rot, 0);
        transform.position = player.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z + 5f);
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
