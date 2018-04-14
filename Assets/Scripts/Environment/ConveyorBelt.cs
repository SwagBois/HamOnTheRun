using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple conveyor belt
public class ConveyorBelt : MonoBehaviour
{
    // Belt trigger collider is 0.98 of X and 0.8 of Z for best detection
    public GameObject belt;
	public Material materialToChangeTo;
	Renderer rendererr;

    // Change in direction swaps endpoints
    public bool direction;

    public Transform[] endpoints;
    public float speed;

    // Moves player to either end depending on direction
    void OnTriggerStay( Collider c )
    {
        // Hardcoding situation for Switch Box for now
        if ( c.transform.tag == "Player" ||
             (c.transform.tag == "Switch Box" && !direction) )
        {
            c.transform.position = Vector3.MoveTowards(
                c.transform.position,
                endpoints[System.Convert.ToUInt32(direction)].position,
                speed * Time.deltaTime
            );
        }
        // else if ( c.transform.tag == "Switch Box" )
        // {
        //     Rigidbody rb = c.transform.GetComponent<Rigidbody>();
                
        // }
    }

    // Called by an activating Switch with a matching conveyor ID
    public void ChangeDirection()
    {
        direction = !direction;
		rendererr = GetComponent<Renderer> ();
		rendererr.material = materialToChangeTo;

    }
}