using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckboxController : MonoBehaviour
{
    public Image checkboxImage;
    public Sprite checkedSprite;
    public Sprite uncheckedSprite;

    private bool isChecked = false;

    private void Start()
    {
        // Initialize checkbox state
        SetCheckboxState(isChecked);
    }

    public void ToggleCheckbox()
    {
        isChecked = !isChecked;
        SetCheckboxState(isChecked);
    }

    private void SetCheckboxState(bool state)
    {
        checkboxImage.sprite = state ? checkedSprite : uncheckedSprite;
    }
}
