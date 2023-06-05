using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToMainMenuButton : MonoBehaviour
{
    private Button returnToMainMenuButton;
    private uiControllers uiController;

    private void Start()
    {
        returnToMainMenuButton = GetComponent<Button>();
        uiController = FindObjectOfType<uiControllers>();

        returnToMainMenuButton.onClick.AddListener(uiController.ReturnToMainMenu);
    }
}