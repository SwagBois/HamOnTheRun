using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))] 
public class PauseMenuController : MonoBehaviour
{

    CanvasGroup pauseMenu;
    public GameObject PausePanel, SettingsPanel, ButtonSound;

    private static PauseMenuController instance = null;

    public static PauseMenuController Instance { get { return instance; } }


	void Awake()
    {
        if ( instance == null )
            instance = this;
        else if ( instance != this )
            Destroy( gameObject );          // Enforce Singleton

        DontDestroyOnLoad( this );

        pauseMenu = GetComponent<CanvasGroup>();
        if ( pauseMenu == null )
		{
            Debug.LogError( "Could not find Canvas Group." );
            return;
		}

		/* Pause menu hidden by default */
        pauseMenu.interactable = false;
        pauseMenu.blocksRaycasts = false;
        pauseMenu.alpha = 0f;
        Time.timeScale = 1f;		
	}

    void Start()
    {
        PausePanel.SetActive(true);
        ButtonSound.SetActive(true);
    }
	
	void Update()
    {
		if ( Input.GetKeyUp (KeyCode.Escape) )
		{
			if ( pauseMenu.interactable )
			{
                pauseMenu.interactable = false;
				pauseMenu.blocksRaycasts = false;
				pauseMenu.alpha = 0f;
				Time.timeScale = 1f;
			}
            else
            {
				pauseMenu.interactable = true;
				pauseMenu.blocksRaycasts = true;
				pauseMenu.alpha = 1f;
				Time.timeScale = 0f;				
			}
		} 
	}

    // Create function in CheckpointManager that resets player to location
    // of the current checkpoint
    // Should be implemented as the same delegate for when player triggers
    // a portal, but instead this will teleport back to the current checkpoint
    // instead of progressing to the next (by incrementing the current chkpt index)
    public void RestartCheckpoint() { CheckpointManager.Instance.CheckpointReset(); }

    // Approach 1 : Set current checkpoint to 0 and move player to it
    // Approach 2 : Reload level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Loads first level (the first scene after the main menu)
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }


    public void ToggleSettings() {}

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
