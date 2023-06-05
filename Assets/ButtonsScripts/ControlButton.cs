using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour
{
    private Button controlButton;
    private uiControllers uiController;

    private void Start()
    {
        controlButton = GetComponent<Button>();
        uiController = FindObjectOfType<uiControllers>();

        controlButton.onClick.AddListener(uiController.ShowInstructions);
    }
}
