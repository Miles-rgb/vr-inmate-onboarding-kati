using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;        // Main Pause Menu panel
    public GameObject settingsPanel;     // Settings Panel
    public GameObject controlsPanel;     // Controls Panel
    public GameObject scenesPanel;       // Scenes Panel
    public InputActionReference pauseActionVR; // Input action for VR pause (e.g., B button)

    private bool isPaused = false;

    void OnEnable()
    {
        if (pauseActionVR != null)
        {
            pauseActionVR.action.performed += TogglePauseVR; // Subscribe to VR input action
        }
    }

    void OnDisable()
    {
        if (pauseActionVR != null)
        {
            pauseActionVR.action.performed -= TogglePauseVR; // Unsubscribe from VR input action
        }
    }

    void Update()
    {
        // Keyboard support (P key)
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    private void TogglePauseVR(InputAction.CallbackContext context)
    {
        TogglePause(); // Call the same toggle function for VR
    }

    private void TogglePause()
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

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Show Pause Menu
        Time.timeScale = 0f;         // Freeze game time
        CloseAllPanels();            // Ensure all sub-panels are closed
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide Pause Menu
        CloseAllPanels();             // Ensure all sub-panels are closed
        Time.timeScale = 1f;          // Resume game time
        isPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void OpenSettings()
    {
        pauseMenuUI.SetActive(false); // Hide Pause Menu
        settingsPanel.SetActive(true); // Show Settings Panel
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false); // Hide Settings Panel
        pauseMenuUI.SetActive(true);   // Show Pause Menu
    }

    public void OpenControls()
    {
        pauseMenuUI.SetActive(false);  // Hide Pause Menu
        controlsPanel.SetActive(true); // Show Controls Panel
    }

    public void CloseControls()
    {
        controlsPanel.SetActive(false); // Hide Controls Panel
        pauseMenuUI.SetActive(true);    // Show Pause Menu
    }

    public void OpenScenes()
    {
        pauseMenuUI.SetActive(false); // Hide Pause Menu
        scenesPanel.SetActive(true);  // Show Scenes Panel
    }

    public void CloseScenes()
    {
        scenesPanel.SetActive(false); // Hide Scenes Panel
        pauseMenuUI.SetActive(true);  // Show Pause Menu
    }

    private void CloseAllPanels()
    {
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        scenesPanel.SetActive(false);
    }
}
