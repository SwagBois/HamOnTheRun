using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBehavior : MonoBehaviour {

    private bool isOn;
    private float increment;

    // Use this for initialization
    void Start()
    {
        isOn = false;
        increment = 0;
    }

	// Update is called once per frame
	void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            Transform blade = transform.GetChild(i);
            blade.transform.Rotate(Vector3.up * Time.deltaTime * increment);
        }
        if (transform.GetChild(3).GetComponent<FanSwitch>().isOn())
        {
            if (increment < 500)
            {
                increment += 5;
                for (int i = 4; i < this.transform.childCount; i++)
                {
                    Transform wind = transform.GetChild(i);
                    wind.GetComponent<WindBehavior>().setFanSpeed((float)increment, (float)500);
                }
            }
        }
        else
        {
            if (increment >= 0)
            {
                increment -= 5;
                for (int i = 4; i < this.transform.childCount; i++)
                {
                    Transform wind = transform.GetChild(i);
                    wind.GetComponent<WindBehavior>().setFanSpeed((float)increment, (float)500);
                }
            }
        }
    }
}
