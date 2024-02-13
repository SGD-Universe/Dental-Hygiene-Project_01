using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideImage : MonoBehaviour
{
    public Image imageToToggle;

    public void ToggleImageVisibility()
    {
        imageToToggle.gameObject.SetActive(!imageToToggle.gameObject.activeSelf);
    }
    
}
