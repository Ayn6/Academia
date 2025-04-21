using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movment : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector3 offset;
    private Vector3 originalPosition;

    [SerializeField] private Transform orifinalParent;
    [SerializeField] private Transform dragLayer;
    [SerializeField] private RectTransform[] objects;

    [SerializeField] private GameObject pallete; 

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 pointerPosition = eventData.position;
        offset = rectTransform.position - pointerPosition;
        originalPosition = rectTransform.position;

        transform.SetParent(dragLayer, false);
    }

    public void OnDrag(PointerEventData eventData) 
    {
        Vector3 pointerPosition = eventData.position;
        rectTransform.position = pointerPosition + offset;
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        if(IsOverLapping())
        {
            transform.SetParent(orifinalParent, false);
            rectTransform.position = originalPosition;
        }
        if (orifinalParent.childCount <= 0) 
        {
            pallete.SetActive(true);
        }
    }

    public void BeginDragExternally(PointerEventData eventData)
    {
        OnBeginDrag(eventData);
    }

    private bool IsOverLapping()
    {
        foreach (RectTransform t in objects) 
        { 
            if(t == null || t == rectTransform || !t.gameObject.activeInHierarchy)
            {
                continue;
            }

            if(RectOverLaps(rectTransform,  t))
            {
                return true;
            }
        }
        return false;
    }

    private bool RectOverLaps(RectTransform a, RectTransform b)
    {
        Rect recA = GetWorldRect(a);
        Rect recB = GetWorldRect(b);

        return recA.Overlaps(recB);
    }

    private Rect GetWorldRect(RectTransform rect)
    {
        Vector3[] corners = new Vector3[4];
        rect.GetWorldCorners(corners);

        Vector3 bottomLeft = corners[0];
        Vector3 TopRight = corners[2];

        return new Rect(bottomLeft, TopRight - bottomLeft);
    }
}
