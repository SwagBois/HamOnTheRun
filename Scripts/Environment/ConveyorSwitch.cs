using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Same as Door switch, except this controls conveyor belts
// TODO: Conveyor animation should show highlighted arrows on belt
// in direction and speed
public class ConveyorSwitch : MonoBehaviour
{
    // Each switch has a list of conveyor belts that it activates
    public List<ConveyorBelt> belts;

    Animator swAnim;

    private bool isTriggered;

    // Hack fix to prevent strange teleporting behavior when animating switch
    private Vector3 initialPos;

    void Awake()
    {
        isTriggered = false;
    }

	void Start()
    {
        swAnim = GetComponent<Animator>();        
	}

    // Test allowing single trigger and switch animation to green for now
    private void OnTriggerEnter( Collider other )
    {
        if ( (other.tag == "Player" || other.tag == "Switch Box") && !isTriggered )
        {
            swAnim.SetBool( "on", true );            
            foreach ( ConveyorBelt belt in belts )
                belt.ChangeDirection();
            isTriggered = true;
        }
    }

}
