using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Logo : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector3 offset;
    private Vector3 originalPosition;

    public List<RectTransform> checkAgainst = new List<RectTransform>();

    private Transform originalParent;
    public Transform dragLayer; // Назначь этот объект в инспекторе

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 pointerPosition = eventData.position;
        offset = rectTransform.position - pointerPosition;
        originalPosition = rectTransform.position;

        originalParent = transform.parent;

        // Переместить в dragLayer
        transform.SetParent(dragLayer, true);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pointerPosition = eventData.position;
        rectTransform.position = pointerPosition + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsOverlappingAnyOtherUI())
        {
            Debug.Log("Наложение обнаружено. Возврат на исходную позицию.");
            transform.SetParent(originalParent, true);
            rectTransform.position = originalPosition;
        }
        else
        {
            Debug.Log("Размещение успешно, ничего не наложилось.");
            // Здесь можешь оставить в dragLayer или переместить на игровое поле
        }
    }
    private bool IsOverlappingAnyOtherUI()
    {
        foreach (RectTransform other in checkAgainst)
        {
            if (other == null || other == rectTransform || !other.gameObject.activeInHierarchy)
                continue;

            if (RectOverlaps(rectTransform, other))
            {
                return true;
            }
        }

        return false;
    }

    private bool RectOverlaps(RectTransform a, RectTransform b)
    {
        Rect rectA = GetWorldRect(a);
        Rect rectB = GetWorldRect(b);

        return rectA.Overlaps(rectB);
    }

    private Rect GetWorldRect(RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);

        Vector3 bottomLeft = corners[0];
        Vector3 topRight = corners[2];
        return new Rect(bottomLeft, topRight - bottomLeft);
    }

    public void Rotate()
    {
        transform.Rotate(0, 0, -90);
    }
}
