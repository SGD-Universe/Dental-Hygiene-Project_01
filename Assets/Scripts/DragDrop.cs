using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    Vector2 objectInitLocalPos;
    int objectInitSiblingIndex;
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
    public static int correctDropCount = 0; // Static count of correctly placed buttons
    public int totalDropsRequired = 10; // Ensure this is set to your desired value
    public IGameTimer gameTimer; // Reference to the common timer interface

    private void Start()
    {
        correctDropCount = 0;
        objectInitLocalPos = objectToDrag.GetComponent<RectTransform>().localPosition;
        objectInitSiblingIndex = objectToDrag.transform.GetSiblingIndex();
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        if (gameTimer == null)
        {
            gameTimer = FindObjectOfType<CountdownTimer>() as IGameTimer ?? FindObjectOfType<TimerController>() as IGameTimer;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        objectToDrag.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DropObject();
    }

    public void DropObject()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = canvas.planeDistance;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);

        if (hitCollider != null && (hitCollider.CompareTag("SpriteLocation1") || hitCollider.CompareTag("SpriteLocation2")))
        {
            if (hitCollider.CompareTag("SpriteLocation1"))
            {
                sprite1.SetActive(true);
            }
        }

        float Distance = Vector3.Distance(objectToDrag.transform.position, ObjectDragToPos.transform.position);

        if (Distance < DropDistance && !IsLocked)
        {
            source.clip = correct;
            source.Play();
            IsLocked = true;
            objectToDrag.transform.position = ObjectDragToPos.transform.position;
            spriteToAppear.GetComponent<Image>().color = targetColor;
            spriteToAppear.SetActive(true);
            correctDropCount++;

            if (correctDropCount >= totalDropsRequired)
            {
                gameTimer.GameOver();
            }

            StartCoroutine(PlayAudioAndDeactivate());
        }
        else if (!IsLocked)
        {
            source.clip = incorrect;
            source.Play();
            objectToDrag.transform.SetAsFirstSibling();
        }
    }

    IEnumerator PlayAudioAndDeactivate()
    {
        objectToDrag.GetComponent<Image>().enabled = false;
        objectToDrag.GetComponent<Button>().enabled = false;
        TMP_Text buttonText = objectToDrag.GetComponentInChildren<TMP_Text>();
        if (buttonText != null)
        {
            buttonText.enabled = false;
        }

        yield return new WaitWhile(() => source.isPlaying);

        gameObject.SetActive(false);
    }
}
