using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button restartButton;
    private uiControllers uiController;

    private void Start()
    {
        restartButton = GetComponent<Button>();
        uiController = FindObjectOfType<uiControllers>();

        restartButton.onClick.AddListener(uiController.RestartGame);
    }
}