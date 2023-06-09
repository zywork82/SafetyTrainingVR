using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private int LRHand = 1; // 0: Left, 1: Right
    [SerializeField] private float amountExtinguishedPerSecond = .1f;
    [SerializeField] private GameObject extSmoke;

    public InputActionProperty leftPress;
    public InputActionProperty rightPress;
    public InputActionProperty leftGrab;
    public InputActionProperty rightGrab;

    private InputActionProperty grabHand;
    private InputActionProperty pressHand;
    private string controllerName;

    private XRGrabInteractable grabInteractable;
    private XRBaseInteractor currentInteractor;

    private bool isGrabbed = false;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
        // grabInteractable.onSelectExit.AddListener(OnReleased);
    }

    void Start() {
        // Initialise Left or Right hand in using Extinguisher
        grabHand = LRHand == 0 ? leftGrab : rightGrab;
        pressHand = LRHand == 0 ? leftPress : rightPress;
        controllerName = LRHand == 0 ? "LeftHand Controller" : "RightHand Controller";
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        currentInteractor = interactor;

        // bool isCorrectObject = (grabInteractable.name == gameObject.name);
        // bool isRightHand = (currentInteractor.name == controllerName);
        isGrabbed = true;
    }
 
    void Update() {
        float rightPressIntensity = rightPress.action.ReadValue<float>();
        bool isPress = rightPressIntensity >= 0.3;

        if (isPress && isGrabbed) {
            extSmoke.SetActive(true);
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 20f) && hit.collider.TryGetComponent(out Flame flame)) {
                bool isLit = flame.TryExtinguish(amountExtinguishedPerSecond * Time.deltaTime);
            } 
        } else {
            extSmoke.SetActive(false);
        }
    }

    // void OnTriggerEnter(Collider other) {
    //     if (other.tag == "Player") {
    //         FindObjectOfType<MissionManager>().SetFireExtinguisherPickedUp();
    //     }
    // }
}
