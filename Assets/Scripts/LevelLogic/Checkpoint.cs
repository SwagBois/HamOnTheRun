using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Level checkpoint
public class Checkpoint : MonoBehaviour
{
    public enum CheckpointType
    {
        NONE, PORTAL
    }

    public CheckpointType checkpointType;

    public GameObject portal;

    public delegate void OnTrigger( Checkpoint cp );
    public OnTrigger trigger;
    public bool isTriggered;

    void Awake()
    {
        trigger = null;
    }

    // If triggered by player the the checkpoint is a portal,
    // run portal teleport coroutine
    public void OnTriggerEnter( Collider c )
    {
        if ( !isTriggered && c.tag == "Player" )
        {
            isTriggered = true;
            if ( checkpointType == CheckpointType.PORTAL )
                StartCoroutine( PortalWithDelay( c, 1.5f ) );
            else if ( checkpointType == CheckpointType.NONE )
                trigger.Invoke( this );
        }
    }

    // Coroutine that portals colliding player after a wait time in real seconds
    private IEnumerator PortalWithDelay( Collider c, float waitTime )
    {
        // Implementation of communication between Checkpoint Manager not yet fixed
        trigger.Invoke( this );
        yield return new WaitForSecondsRealtime( waitTime );
        c.transform.position = portal.transform.position;        
    }
}