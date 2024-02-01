using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableDropdownOption : MonoBehaviour
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasScaler canvasScaler;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasScaler = GetComponentInParent<CanvasScaler>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Calculate the position in canvas space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out Vector2 localPos);

        // Move the button to the calculated position
        rectTransform.localPosition = localPos;

        Vector2 newPosition = rectTransform.anchoredPosition + eventData.delta;

        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        float minX = corners[0].x;
        float minY = corners[0].y;
        float maxX = corners[1].x;
        float maxY = corners[1].y;

        rectTransform.anchoredPosition = newPosition;
    }


}
