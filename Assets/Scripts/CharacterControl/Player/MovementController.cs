﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float speed = 5;
    public GameObject mainCamera;
    private Vector3[][] direction;
    private PlayerController player;
	private Animator anim;
    private int[] count;

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

        count = new int[4];

		anim = GetComponent<Animator>();
		anim.SetBool ("isWalking",false);
    }
	
	// Update is called once per frame
	void Update () {
        int index = mainCamera.GetComponent<CameraController>().getIndex();
		anim.SetBool ("isWalking",false);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            /*if(count[0] == 0)
            {
                GameObject.Find("Armature").transform.Rotate(0, 0, 90);

                count[0]++;
            }*/
            
            transform.Translate(speed * direction[index][0] * Time.deltaTime);
			anim.SetBool ("isWalking",true);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            /*count[0] = 0;
            count[2] = 0;
            count[3] = 0;
            if (count[1] == 0)
            {
                GameObject.Find("Armature").transform.Rotate(0, 0, -90);
                count[1]++;
            }*/
            transform.Translate(speed * direction[index][1] * Time.deltaTime);
			anim.SetBool ("isWalking",true);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            /*if (count[2] == 0)
            {
                count[0] = 0;
                count[1] = 0;
                count[3] = 0;
                GameObject.Find("Armature").transform.Rotate(0, 0, 0);
                count[2]++;
            }*/
            transform.Translate(speed * direction[index][2] * Time.deltaTime);
			anim.SetBool ("isWalking",true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            /*if (count[3] == 0)
            {
                count[0] = 0;
                count[1] = 0;
                count[2] = 0;
                GameObject.Find("Armature").transform.Rotate(0, 0, 180);
                count[3]++;
            }*/
            transform.Translate(speed * direction[index][3] * Time.deltaTime);
			anim.SetBool ("isWalking",true);
        }

        if(player.getIndex() == 1 && Input.GetKey(KeyCode.Space))
        {
            transform.Translate(6 * Vector3.up * Time.deltaTime);
			anim.SetBool ("isWalking",true);
        }

    }
}