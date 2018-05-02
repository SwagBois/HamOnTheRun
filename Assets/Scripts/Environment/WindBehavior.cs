using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBehavior : MonoBehaviour {

    public int speed;
    private float fanSpeed;

    // Use this for initialization
    void Start()
    {

    }

    public void setFanSpeed(float newSpeed, float maxSpeed)
    {
        fanSpeed = newSpeed/maxSpeed;
    }

	// Update is called once per frame
	void OnCollisionStay(Collision c)
    {
        if (c.gameObject.tag == "Player" || c.gameObject.tag == "Crates" || c.gameObject.tag == "Player-Push")
        {
            Rigidbody rb = c.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = this.transform.up*fanSpeed*speed;
                Debug.LogWarning(rb.velocity);
            }
        }
    }

	// Update is called once per frame
	void OnTriggerStay(Collider c)
	{
		if (c.tag == "Player" || c.tag == "Crates" || c.tag == "Player-Push")
		{
			Rigidbody rb = c.GetComponent<Rigidbody>();
			if (rb != null)
			{
				rb.velocity = this.transform.up*fanSpeed*speed;
				Debug.LogWarning(rb.velocity);
			}
		}
	}
}
