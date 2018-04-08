using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float speed = 5;
    public GameObject mainCamera;
    private Vector3[][] direction;
    private PlayerController player;

    // Use this for initialization
    void Start () {
        player = GetComponent<PlayerController>();
        Vector3[] d0 = new Vector3[4] {Vector3.right, Vector3.left, Vector3.forward, Vector3.back };
        Vector3[] d1 = new Vector3[4] { Vector3.back, Vector3.forward, Vector3.right, Vector3.left };
        Vector3[] d2 = new Vector3[4] { Vector3.left, Vector3.right, Vector3.back, Vector3.forward };
        Vector3[] d3 = new Vector3[4] { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        direction = new Vector3[4][];
        direction[0] = d0;
        direction[1] = d1;
        direction[2] = d2;
        direction[3] = d3;
    }
	
	// Update is called once per frame
	void Update () {
        int index = mainCamera.GetComponent<CameraController>().getIndex();

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * direction[index][0] * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(speed * direction[index][1] * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(speed * direction[index][2] * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(speed * direction[index][3] * Time.deltaTime);
        }

        if(player.getIndex() == 1 && Input.GetKey(KeyCode.Space))
        {
            transform.Translate(speed * Vector3.up * Time.deltaTime);
        }

    }
}
