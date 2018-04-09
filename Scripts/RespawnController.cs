using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Determines when and how to reset the player character
public class RespawnController : MonoBehaviour
{
    // Reference to special floor type
    public GameObject magma;

    // Reference to a single instance of RespawnController
    private static RespawnController instance = null;

    // Other classes will access Controller through an Instance
    public static RespawnController Instance { get { return instance; } }

    // Initialize RespawnController instance if it has not been already
    void Awake()
    {
        if ( instance == null )
            instance = this;
        else if ( instance != this )
            Destroy( gameObject );          // Enforce Singleton

        DontDestroyOnLoad( this );
    }

    // Check for player collision with magma and display greyed overlay
    // Then reset to Stage 1 Start Checkpoint
    public void Respawn()
    {

    }
}