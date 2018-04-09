using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Checkpoint system
public class CheckpointManager : MonoBehaviour
{
    // Current checkpoint
    private int currentIndex = 0;
    // List of checkpoints in level
    public List<Checkpoint> checkpoints = new List<Checkpoint>();
    // Reference to a single instance of CheckpointManager
    private static CheckpointManager instance = null;

    // Read-only Properties
    public List<Checkpoint> Checkpoints { get { return checkpoints; } }
    // Other classes will access Manager through an Instance    
    public static CheckpointManager Instance { get { return instance; } }
    public Checkpoint CurrentCheckpoint
    {
        get
        {
            return (currentIndex > -1) ? checkpoints[currentIndex] : null;
        }
    }

    // Initialize CheckpointManager instance if it has not been already
    void Awake()
    {
        if ( instance == null )
            instance = this;
        else if ( instance != this )
            Destroy( gameObject );          // Enforce Singleton

        DontDestroyOnLoad( this );

        // Add all children to Checkpoints list
        for ( int i = 0;  i < transform.childCount; i++ )
        {
            Checkpoint checkpoint = transform.GetChild(i).GetComponent<Checkpoint>();
            checkpoint.trigger += OnCheckPointTriggered;
            checkpoints.Add( checkpoint );
        }
    }

    // Called on player death, game completion/play again, or manual reset
    public void LevelReset() =>
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );

    // Call when a checkpoint is triggered.
    // Currently there are only two checkpoints, the reset position from start
    // and stage 2. We can use the current index to handle where to reset the
    // the player controller position to on death/respawn
    public void OnCheckPointTriggered( Checkpoint cp ) =>
        currentIndex = checkpoints.IndexOf( cp );
}