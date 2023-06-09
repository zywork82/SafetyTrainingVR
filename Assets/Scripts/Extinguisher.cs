using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private float amountExtinguishedPerSecond = .1f;
    [SerializeField] private GameObject extSmoke;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    private XRGrabInteractable grabInteractable;
    private XRBaseInteractor currentInteractor;

    private bool isGrabbed = false;

    void Start() {
        // rightActivate.action.Enable();
    }

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEnter.AddListener(OnGrabbed);
        // grabInteractable.onSelectExit.AddListener(OnReleased);
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        currentInteractor = interactor;

        bool isCorrectObject = (grabInteractable.name == gameObject.name);
        bool isRightHand = (currentInteractor.name == "RightHand Controller");
        isGrabbed = isCorrectObject && isRightHand;
        rightActivate.action.Disable();
        Debug.Log("isGrabbed is: " + isGrabbed);
    }
 
    void Update() {
        float leftActivateIntensity = leftActivate.action.ReadValue<float>();
        bool isPress = leftActivateIntensity >= 0.3;

        if (isPress) {
            extSmoke.SetActive(true);
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 20f) && hit.collider.TryGetComponent(out Flame flame)) {
                bool isLit = flame.TryExtinguish(amountExtinguishedPerSecond * Time.deltaTime);
            } 
        } else {
            extSmoke.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            // Tell mission manager complete mission 1
            print("collided with player");
            FindObjectOfType<MissionManager>().isFireExtinguisherPickedUp = true;
        }
    }
}
