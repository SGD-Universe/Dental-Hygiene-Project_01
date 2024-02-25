using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownToggle : MonoBehaviour
{

    public GameObject dropdownContent;
    private bool isDropdownVisible = false;

    //allows you to toggle the visibility of a dropdown panel by activating or deactivating the associated GameObject
    public void ToggleDropdownPanel()
    {
        isDropdownVisible = !isDropdownVisible;
        dropdownContent.SetActive(isDropdownVisible);
    }

   
}
