using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameManager : MonoBehaviour
{
    public GameObject[] flames;
    public bool isAtLeastOneLit = false;

    void Update() {
        if (isAllFlamesPutOut()) {
            print("put out flame");
            FindObjectOfType<MissionManager>().SetFlamePutOut();
            print("HERE");
        }
    }

    private bool isAllFlamesPutOut() {
        print("A");
        isAtLeastOneLit = false;

        foreach(GameObject flame in flames) {
            checkIfLit(isAtLeastOneLit, flame.GetComponent<Flame>().isLit);
        }
         print("B");
        return !isAtLeastOneLit;
    }

    private void checkIfLit(bool cumulativeIsLit, bool currIsLit) {
         print("C");
        isAtLeastOneLit = cumulativeIsLit || currIsLit;
         print("D");

    }
}
