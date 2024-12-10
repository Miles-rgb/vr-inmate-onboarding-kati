using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;    // Reference to the main menu panel
    public GameObject settingsPanel;   // Reference to the settings panel
    public GameObject scenesPanel;     // Reference to the scenes panel
    public GameObject controlsPanel;   // Reference to the controls panel

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);  // Hide the main menu
        settingsPanel.SetActive(true);   // Show settings panel
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);  // Hide settings panel
        mainMenuPanel.SetActive(true);   // Show the main menu
    }

    public void OpenScenes()
    {
        mainMenuPanel.SetActive(false);  // Hide the main menu
        scenesPanel.SetActive(true);     // Show scenes panel
    }

    public void CloseScenes()
    {
        scenesPanel.SetActive(false);    // Hide scenes panel
        mainMenuPanel.SetActive(true);   // Show the main menu
    }

    public void OpenControls()
    {
        mainMenuPanel.SetActive(false);  // Hide the main menu
        controlsPanel.SetActive(true);   // Show controls panel
    }

    public void CloseControls()
    {
        controlsPanel.SetActive(false);  // Hide controls panel
        mainMenuPanel.SetActive(true);   // Show the main menu
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex); // Load a specific scene
    }
}
