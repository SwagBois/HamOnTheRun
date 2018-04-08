using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Level checkpoint
public class Checkpoint : MonoBehaviour
{

    public GameObject portal;

    private void OnTriggerEnter( Collider c )
    {
        if( c.tag == "Player" )
            c.transform.position = portal.transform.position;
    }
}