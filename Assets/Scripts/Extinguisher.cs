using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private float amountExtinguishedPerSecond = .1f;
    [SerializeField] private GameObject extSmoke;

    void Update() {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 100f) && hit.collider.TryGetComponent(out Flame flame)) {
            bool isLit = flame.TryExtinguish(amountExtinguishedPerSecond * Time.deltaTime);
            if (isLit) {
                extSmoke.SetActive(true);
            } else {
                extSmoke.SetActive(false);
            }
        }
    }
}
