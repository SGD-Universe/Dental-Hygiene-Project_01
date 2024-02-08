using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour, IDropHandler
{
    public AudioSource source;
    public AudioClip correct;
    public AudioClip incorrect;

   
    public void OnDrop(PointerEventData eventData)
    {
        // Check if the dropped item is correct
        bool isCorrectDrop = CheckCorrectDrop(eventData);

        // Play correct or incorrect sound effect accordingly
        if (source != null)
        {
            if (isCorrectDrop && correct != null)
            {
                source.PlayOneShot(correct);
            }
            else if (!isCorrectDrop && incorrect != null)
            {
                source.PlayOneShot(incorrect);
            }
        }

        
    }

    bool CheckCorrectDrop(PointerEventData eventData)
    {
        RectTransform dropZone = GetComponent<RectTransform>(); // Example drop zone

        // Convert screen space position to local position
        Vector2 localPointerPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(dropZone, eventData.position, eventData.pressEventCamera, out localPointerPosition);

        // Check if the local position is within the drop zone's bounds
        if (dropZone.rect.Contains(localPointerPosition))
        {
            return true; // Drop is correct
        }
        else
        {
            return false; // Drop is incorrect
        }
    }
}
        
