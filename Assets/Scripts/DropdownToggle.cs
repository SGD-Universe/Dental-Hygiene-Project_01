using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownToggle : MonoBehaviour
{

    public GameObject dropdownContent;
    private bool isDropdownVisible = false;

    public void ToggleDropdownPanel()
    {
        isDropdownVisible = !isDropdownVisible;
        dropdownContent.SetActive(isDropdownVisible);
    }

   
}
