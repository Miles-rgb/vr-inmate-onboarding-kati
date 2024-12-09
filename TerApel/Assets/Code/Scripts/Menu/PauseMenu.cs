using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;        // The main pause menu panel
    public GameObject settingsPanel;     // The settings panel
    public GameObject confirmQuitPanel;  // Confirmation panel for quitting
    public GameObject confirmMainMenuPanel; // Confirmation panel for main menu
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rightHandRay; // Ray Interactor for VR UI
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor leftHandRay;  // Optional: Left-hand Ray Interactor
    public InputActionReference pauseAction; // Input action for pausing (for VR controllers)

    private bool isPaused = false;

    void Start()
    {
        // Ensure the menu starts hidden
        pauseMenuUI.SetActive(false);
        settingsPanel.SetActive(false);
        confirmQuitPanel.SetActive(false);
        confirmMainMenuPanel.SetActive(false);

        // Enable ray interaction when the menu is active
        ToggleRayInteractors(false);

        // Subscribe to pause action
        if (pauseAction != null)
        {
            pauseAction.action.performed += OnPauseAction;
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from pause action
        if (pauseAction != null)
        {
            pauseAction.action.performed -= OnPauseAction;
        }
    }

    void Update()
    {
        // Allow keyboard controls for pausing
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void OnPauseAction(InputAction.CallbackContext context)
    {
        // Handle VR pause input
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Show pause menu
        Time.timeScale = 0f;         // Freeze game time
        isPaused = true;
        ToggleRayInteractors(true);  // Enable ray interaction for VR
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide pause menu
        settingsPanel.SetActive(false); // Ensure settings panel is hidden
        confirmQuitPanel.SetActive(false); // Hide quit confirmation panel
        confirmMainMenuPanel.SetActive(false); // Hide main menu confirmation panel
        Time.timeScale = 1f;           // Resume game time
        isPaused = false;
        ToggleRayInteractors(false);   // Disable ray interaction for VR
    }

    public void OpenSettings()
    {
        pauseMenuUI.SetActive(false); // Hide pause menu
        settingsPanel.SetActive(true); // Show settings panel
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false); // Hide settings panel
        pauseMenuUI.SetActive(true);   // Show pause menu
    }

    public void ShowConfirmQuit()
    {
        pauseMenuUI.SetActive(false);   // Hide pause menu
        confirmQuitPanel.SetActive(true); // Show quit confirmation panel
    }

    public void ConfirmQuit()
    {
        Debug.Log("Quit Game!");
        Application.Quit(); // Quit the game
    }

    public void CancelQuit()
    {
        confirmQuitPanel.SetActive(false); // Hide quit confirmation panel
        pauseMenuUI.SetActive(true);       // Show pause menu
    }

    public void ShowConfirmMainMenu()
    {
        pauseMenuUI.SetActive(false);       // Hide pause menu
        confirmMainMenuPanel.SetActive(true); // Show main menu confirmation panel
    }

    public void ConfirmMainMenu()
    {
        Time.timeScale = 1f; // Resume game time before loading the main menu
        SceneManager.LoadScene("MainMenu"); // Load main menu scene (replace with your scene name)
    }

    public void CancelMainMenu()
    {
        confirmMainMenuPanel.SetActive(false); // Hide main menu confirmation panel
        pauseMenuUI.SetActive(true);          // Show pause menu
    }

    private void ToggleRayInteractors(bool enable)
    {
        if (rightHandRay != null)
            rightHandRay.gameObject.SetActive(enable);

        if (leftHandRay != null)
            leftHandRay.gameObject.SetActive(enable);
    }
}
