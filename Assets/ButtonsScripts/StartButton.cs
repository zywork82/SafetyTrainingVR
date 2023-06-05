using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button startButton;
    private uiControllers uiController; // Note the updated class name

    private void Start()
    {
        startButton = GetComponent<Button>();
        uiController = FindObjectOfType<uiControllers>(); // Note the updated class name

        startButton.onClick.AddListener(uiController.StartGame);
    }
}
