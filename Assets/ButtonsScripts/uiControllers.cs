using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiControllers : MonoBehaviour
{
    public GameObject controlsPanel; // Reference to the ControlsPanel game object

    private void Start()
    {
        // Deactivate the controls panel at the start
        controlsPanel.SetActive(false);
    }

    public void StartGame()
    {
        // Load the game scene or start the game process
        SceneManager.LoadScene("MainVRScene");
    }

    public void QuitTraining()
    {
        // Code to handle the quit button functionality
        // Quit the training application or return to the main menu
        Application.Quit();
    }
        
    public void ShowInstructions()
    {
        // Code to handle the control button functionality
        // Show a pop-up panel with instructions or additional information
        // Activate the instructions panel to make it visible
         // Toggle the visibility of the controls panel
        controlsPanel.SetActive(!controlsPanel.activeSelf);
    }

    public void CloseInstructions(){
        controlsPanel.SetActive(false);
    }


    public void RestartGame()
    {
        // Restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        // Load the main menu scene or go back to the homepage
        SceneManager.LoadScene("UI For VR Training");
    }

}
