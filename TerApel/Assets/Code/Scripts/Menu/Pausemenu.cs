using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;        // Main Pause Menu panel
    public GameObject settingsPanel;     // Settings Panel
    public GameObject controlsPanel;     // Controls Panel
    public GameObject scenesPanel;       // Scenes Panel
    public Transform playerHead;         // Reference to the player's head (Main Camera or XR Rig camera)
    public float menuDistance = 2f;      // Distance in front of the player where panels should appear
    public InputActionReference pauseAction; // Reference to the input action for pausing

    private bool isPaused = false;

    void OnEnable()
    {
        if (pauseAction != null)
        {
            pauseAction.action.Enable(); // Ensure the action is enabled
            pauseAction.action.performed += TogglePause; // Subscribe to the input action
        }
    }

    void OnDisable()
    {
        if (pauseAction != null)
        {
            pauseAction.action.performed -= TogglePause; // Unsubscribe from the input action
            pauseAction.action.Disable(); // Disable the action
        }
    }

    void Update()
    {
        // Check if the P key is pressed for keyboard input
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            TogglePause(new InputAction.CallbackContext());
        }
    }

    private void TogglePause(InputAction.CallbackContext context)
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
        PositionPanel(pauseMenuUI); // Position the pause menu in front of the player
        pauseMenuUI.SetActive(true); // Show Pause Menu
        CloseAllPanels();            // Ensure all sub-panels are closed
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide Pause Menu
        CloseAllPanels();             // Ensure all sub-panels are closed
        isPaused = false;
    }

    public void OpenSettings()
    {
        PositionPanel(settingsPanel); // Position Settings Panel
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
        PositionPanel(controlsPanel); // Position Controls Panel
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
        PositionPanel(scenesPanel); // Position Scenes Panel
        pauseMenuUI.SetActive(false); // Hide Pause Menu
        scenesPanel.SetActive(true);  // Show Scenes Panel
    }

    public void CloseScenes()
    {
        scenesPanel.SetActive(false); // Hide Scenes Panel
        pauseMenuUI.SetActive(true);  // Show Pause Menu
    }

    private void PositionPanel(GameObject panel)
    {
        if (playerHead != null && panel != null)
        {
            // Position the panel in front of the player's view
            Vector3 forward = playerHead.forward;
            forward.y = 0; // Keep the panel level with the player
            panel.transform.position = playerHead.position + forward.normalized * menuDistance; // Set position
            panel.transform.rotation = Quaternion.LookRotation(forward, Vector3.up); // Rotate to face player
        }
    }

    private void CloseAllPanels()
    {
        // Close all sub-panels
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        scenesPanel.SetActive(false);
    }
}

