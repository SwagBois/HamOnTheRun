using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Conveyor belt/switch interaction
public class ConveyorSystem : MonoBehaviour
{
    //Reference to a single instance of ConveyorSystem
    private static ConveyorSystem instance = null;

    // Read-only Properties
    public static ConveyorSystem Instance { get { return instance; } }

    // Initialize CheckpointManager instance if it has not been already
    void Awake()
    {
        if ( instance == null )
            instance = this;
        else if ( instance != this )
            Destroy( gameObject );          // Enforce Singleton

        DontDestroyOnLoad( this );
    }
}