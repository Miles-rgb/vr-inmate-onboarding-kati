using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;  // Reference to the main menu panel
    public GameObject settingsPanel; // Reference to the settings panel
    public GameObject scenesPanel;   // Reference to the scenes panel
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rightHandRay; // Ray interactor for VR UI
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor leftHandRay;  // Optional: Left-hand ray interactor
    public InputActionReference selectAction; // Action for selecting buttons in VR

    void Start()
    {
        // Ensure the main menu starts active and other panels are hidden
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        scenesPanel.SetActive(false);

        // Enable ray interactors for VR
        ToggleRayInteractors(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit(); // Quit the application
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false); // Hide the main menu
        settingsPanel.SetActive(true);  // Show the settings panel
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false); // Hide the settings panel
        mainMenuPanel.SetActive(true);  // Show the main menu
    }

    public void OpenScenes()
    {
        mainMenuPanel.SetActive(false); // Hide the main menu
        scenesPanel.SetActive(true);    // Show the scenes panel
    }

    public void CloseScenes()
    {
        scenesPanel.SetActive(false);   // Hide the scenes panel
        mainMenuPanel.SetActive(true);  // Show the main menu
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex); // Load a specific scene by its index
    }

    private void ToggleRayInteractors(bool enable)
    {
        if (rightHandRay != null)
            rightHandRay.gameObject.SetActive(enable);

        if (leftHandRay != null)
            leftHandRay.gameObject.SetActive(enable);
    }
}
