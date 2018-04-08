using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple conveyor belt
public class ConveyorBelt : MonoBehaviour
{

    // BoxCollider bc;
    public GameObject belt, sw;

    // Change in direction swaps endpoints
    public bool direction;

    public Transform[] endpoints;
    public float speed;

    // Moves player to either end depending on direction
    void OnTriggerStay( Collider c )
    {
        c.transform.position = Vector3.MoveTowards(
            c.transform.position,
            endpoints[System.Convert.ToUInt32(direction)].position,
            speed * Time.deltaTime
        );
    }

    // Called by an activating Switch with a matching conveyor ID
    public void ChangeDirection() => direction = !direction;
}