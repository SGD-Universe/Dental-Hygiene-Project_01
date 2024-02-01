using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpriteAppearOnDrop : MonoBehaviour
{
    void Start()
    {
        // Set the sprite to be initially inactive
        gameObject.SetActive(false);
    }
}
