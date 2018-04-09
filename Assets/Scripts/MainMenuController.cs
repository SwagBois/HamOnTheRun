using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject Startpanel, AboutPanel, ButtonSound;

    void Start()
    {
        AboutPanel.SetActive(false);
        ButtonSound.SetActive(true);
        Startpanel.SetActive(true);
    }

    // Build priority by scene order:
    // Main Menu - 0
    // Level 1   - 1
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void About()
    {
        AboutPanel.SetActive(true);
        Startpanel.SetActive(false);
    }

    public void Back()
    {
        AboutPanel.SetActive(false);
        Startpanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
