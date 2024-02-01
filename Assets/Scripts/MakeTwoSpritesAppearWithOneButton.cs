using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class MakeTwoSpritesAppearWithOneButton : MonoBehaviour
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    public GameObject sprite1;
    public GameObject sprite2;
    Vector2 objectInitPos;
    public GameObject objectToDrag;
    public GameObject ObjectDragToPos;
    public GameObject ObjectDragToPos2;

    public bool IsLocked;
    public float DropDistance;
    public RectTransform targetLocation;
    public Color targetColor = Color.green;
    public GameObject spriteToAppear;
    
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

    }

    public void OnDrag()
    {
        if (!IsLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }
    }

    public void DropObject()
    {
        // Add logic to check if the button is dropped on either sprite location
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = canvas.planeDistance;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);

        if (hitCollider != null)
        {
            // Button dropped, make both sprites appear
            sprite1.SetActive(true);
            sprite2.SetActive(true);

            canvasGroup.alpha = 0; // Make the button invisible
            canvasGroup.blocksRaycasts = false; // Disable raycasts on the button
        }
        float Distance = Vector3.Distance(objectToDrag.transform.position, ObjectDragToPos.transform.position);

        if (Distance < DropDistance)
        {
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
        }
    }




}
