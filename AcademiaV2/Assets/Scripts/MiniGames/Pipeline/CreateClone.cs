using UnityEngine;
using UnityEngine.EventSystems;

public class CreateClone : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform dragParent; // Например, Canvas
    [SerializeField] private GameObject prefabToClone; // Префаб текущего объекта

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject clone = Instantiate(prefabToClone, dragParent);
        RectTransform cloneRect = clone.GetComponent<RectTransform>();

        // Устанавливаем клон в центр dragParent
        cloneRect.anchoredPosition = Vector2.zero;

        // Копируем масштаб и размеры (если нужно)
        RectTransform originalRect = GetComponent<RectTransform>();
        cloneRect.localScale = originalRect.localScale;
        cloneRect.sizeDelta = originalRect.sizeDelta;

        // Активируем перетаскивание, если есть drag-скрипт
        var draggable = clone.GetComponent<Movment>();
        var createClone = clone.GetComponent<CreateClone>();
        var rotation = clone.GetComponent<Rotation>();
        draggable.enabled = true;
        rotation.enabled = true;
        createClone.enabled = false;
        if (draggable != null)
        {
            draggable.BeginDragExternally(eventData);
        }
    }
}
