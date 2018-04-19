using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Checkpoint system
public class CheckpointManager : MonoBehaviour
{
    // Reference to player
    public GameObject player;
    // Current checkpoint
    public int currentIndex = 0;
    // List of checkpoints in level
    public List<Checkpoint> checkpoints = new List<Checkpoint>();
    // Reference to a single instance of CheckpointManager
    private static CheckpointManager instance = null;
    // Reference to PlayerController
    public PlayerController playerController;

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

        DontDestroyOnLoad( this );          // Preserves manager scross scenes

        // Add all children to Checkpoints list
        for ( int i = 0;  i < transform.childCount; i++ )
        {
            Checkpoint checkpoint = transform.GetChild(i).GetComponent<Checkpoint>();
            checkpoint.trigger += OnCheckPointTriggered;
            checkpoints.Add( checkpoint );
        }
    }

    void Update()
    {
        // Will be efficient if we have multiple controllable pigs at the same time
        player = GameObject.Find("Main Pig");        
        // Reached last checkpoint, show Game Over screen
        if ( currentIndex == checkpoints.Capacity - 1 )
        {
            // Show game over screen, instead we temporarily reload the level
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
    }

    public void CheckpointInit()
    {
        currentIndex = 0;
    }

    public void CheckpointReset()
    {
        if ( checkpoints[currentIndex].checkpointType == Checkpoint.CheckpointType.NONE ||
             checkpoints[currentIndex].checkpointType == Checkpoint.CheckpointType.START )
            player.transform.position = checkpoints[currentIndex].transform.position;
    }

    // Call when a checkpoint is triggered.
    // Currently there are only two checkpoints, the reset position from start
    // and stage 2. We can use the current index to handle where to reset the
    // the player controller position to on death/respawn
    public void OnCheckPointTriggered( Checkpoint cp)
    {
        currentIndex = checkpoints.IndexOf(cp);
    }

}