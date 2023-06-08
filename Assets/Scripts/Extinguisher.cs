using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private float amountExtinguishedPerSecond = .1f;
    [SerializeField] private GameObject extSmoke;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    void Update() {
        float rightActivateIntensity = rightActivate.action.ReadValue<float>();
        float leftActivateIntensity = leftActivate.action.ReadValue<float>();
        bool isPress = rightActivateIntensity >= 0.3 || leftActivateIntensity >= 0.3;

        if (isPress) {
            extSmoke.SetActive(true);
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 20f) && hit.collider.TryGetComponent(out Flame flame)) {
                bool isLit = flame.TryExtinguish(amountExtinguishedPerSecond * Time.deltaTime);
            } 
        } else {
            extSmoke.SetActive(false);
        }
    }
}
