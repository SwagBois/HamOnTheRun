using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSwitch : MonoBehaviour {

    private bool switchOn = false;

    void Update()
    {
        if (switchOn)
        {
            transform.GetComponent<Renderer>().material.color = Color.green;
            return;
        }
        transform.GetComponent<Renderer>().material.color = Color.red;
    }

	void OnCollisionStay(Collision c)
    {
        if (c.gameObject.tag == "Player" || c.gameObject.tag == "Player-Push" || c.gameObject.tag == "Crates")
        {
            switchOn = true;
        }
    }
    void OnCollisionExit(Collision c)
    {
        switchOn = false;
    }

    public bool isOn()
    {
        return switchOn;
    }
}
