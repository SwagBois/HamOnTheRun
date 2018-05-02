using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBehavior : MonoBehaviour {

    private float startZ;
    private float endZ;
    private bool canExtend;
    public Transform[] switches;

	// Use this for initialization
	void Start () {
        startZ = this.transform.position.z;
        endZ = this.transform.position.z + 9;
        canExtend = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        int counter = 0;
		foreach (Transform aSwitch in switches)
        {
            if (aSwitch.GetComponent<FanSwitch>().isOn())
            {
                counter++;
            }
        }
        if (counter == switches.Length)
        {
            if (this.transform.position.z > startZ)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - (1 * Time.deltaTime));
            }
        }
        else
        {
            if (this.transform.position.z < endZ)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + (1 * Time.deltaTime));
            }
        }
	}
}
