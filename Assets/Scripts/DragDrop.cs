using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour

{
    private RectTransform rectTransform;
    Vector2 objectInitPos;
    public GameObject objectToDrag;
    public GameObject ObjectDragToPos;
    public bool IsLocked;
    public float DropDistance;
    private Canvas canvas;
    public RectTransform targetLocation;
    public Color targetColor = Color.green;
    public GameObject spriteToAppear;
    public GameObject sprite1;
    public AudioSource source;
    public AudioClip correct;
    public AudioClip incorrect;
    
    





    private void Start()
    {
        objectInitPos = objectToDrag.transform.position;
        rectTransform = GetComponent<RectTransform>(); 
        canvas = GetComponentInParent<Canvas>();
    }

    public void DragObject()
    {
        if (!IsLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }

      
    }

    public void DropObject()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = canvas.planeDistance;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);

        if (hitCollider != null && (hitCollider.CompareTag("SpriteLocation1") || hitCollider.CompareTag("SpriteLocation2")))
        {
            // Button dropped on sprite location, make the sprites appear
            if (hitCollider.CompareTag("SpriteLocation1"))
            {
                sprite1.SetActive(true);
                
            }

      
        }
        float Distance = Vector3.Distance(objectToDrag.transform.position, ObjectDragToPos.transform.position);

        if (Distance < DropDistance)
        {
            source.clip = correct;
            source.Play();
            IsLocked = true;
            objectToDrag.transform.position = ObjectDragToPos.transform.position;
            

            // Button reached the target location
            gameObject.SetActive(false); // Hide the button
            targetLocation.GetComponent<Image>().color = targetColor; // Change target color

            // Make the sprite appear
            spriteToAppear.SetActive(true);

            

            
        }
        else
        {
            objectToDrag.transform.position = objectInitPos;
            source.clip = incorrect;
            source.Play();
           
            
        }

       


    }

  

}
