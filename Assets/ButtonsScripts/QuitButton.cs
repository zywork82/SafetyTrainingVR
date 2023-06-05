using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    private Button quitButton;
    private uiControllers uiController;

    private void Start()
    {
        quitButton = GetComponent<Button>();
        uiController = FindObjectOfType<uiControllers>();

        quitButton.onClick.AddListener(uiController.QuitTraining);
    }
}
