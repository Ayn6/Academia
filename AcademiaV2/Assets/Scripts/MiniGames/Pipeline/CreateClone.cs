using UnityEngine;
using UnityEngine.EventSystems;

public class CreateClone : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform dragParent;
    private GameObject clone;

    public void OnPointerDown(PointerEventData eventData)
    {
        clone = Instantiate(gameObject, transform.parent);
        Destroy(clone.GetComponent<CreateClone>())
        RectTransform cloneRect = clone.GetComponent<RectTransform>();


    }

    ondrag (PointerEventData eventData) {
        cloneRect.position = eventData.position;
    }

    PointerEnd() {
        clone = null;
    }
}
