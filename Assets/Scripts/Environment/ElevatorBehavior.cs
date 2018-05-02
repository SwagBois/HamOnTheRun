using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehavior : MonoBehaviour {

    private float startY;
    private float endY;
    public float height;
    private bool isGoingDown;


	// Use this for initialization
	void Start () {
        startY = this.transform.position.y;
        endY = this.transform.position.y - (float)height;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isGoingDown)
        {
            if (this.transform.position.y > startY)
            {
                isGoingDown = true;
                return;
            }
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (1 * Time.deltaTime), this.transform.position.z);
        }
        else
        {
            if (this.transform.position.y < endY)
            {
                isGoingDown = false;
                return;
            }
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (1 * Time.deltaTime), this.transform.position.z);
        }
	}
}
