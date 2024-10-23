using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideImage : MonoBehaviour
{
    public GameObject[] guideImages;

    public void ToggleImageVisibility(int index)
    {
        foreach (GameObject obj in guideImages)
        {
            obj.SetActive(false);
        }

        if (index >= 0 && index < guideImages.Length)
        {
            guideImages[index].SetActive(true);
        }
    }
    
}
