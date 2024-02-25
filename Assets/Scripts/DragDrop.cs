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
        //stores the initial position of the GameObject
        objectInitPos = objectToDrag.transform.position;
        //fetches the RectTransform component attached to the same GameObject
        rectTransform = GetComponent<RectTransform>();
        //fetches the Canvas component from the parent hierarchy of the GameObject where the script is attached and assigns it to a variable for further use
        canvas = GetComponentInParent<Canvas>();
    }

    public void DragObject()
    {
        //sets the position of the GameObject to the current position of the mouse cursor on the screen
        if (!IsLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }

      
    }

    public void DropObject()
    {
        //assigns the current position of the mouse cursor to the mousePosition variable, allowing you to use this variable to work with the mouse position in your script.
        Vector3 mousePosition = Input.mousePosition;
        //convert mouse positions from screen space to world space
        mousePosition.z = canvas.planeDistance;
        // convert positions from screen space (such as mouse positions) to world space, allowing you to interact with objects in the scene based on their world positions.
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //detects collisions at a specific point in 2D world space.
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

        //controls the behavior of the dragged object when it is close enough to its target position, locking it in place and snapping it to the target position.
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
