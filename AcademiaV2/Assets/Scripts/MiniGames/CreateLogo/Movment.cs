using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movment : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Vector3 offset;
    private Vector3 originalPosition;

    [SerializeField] private Transform orifinalParent;
    [SerializeField] private Transform dragLayer;
    [SerializeField] private RectTransform[] objects;

    [SerializeField] private GameObject pallete; 

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Берем точку под пальцем
        Vector3 pointerPosition = eventData.position;
        // Выщитываем расстояние между пальцем и объектом
        offset = rectTransform.position - pointerPosition;
        // Сохраняем начальную позицию объекта
        originalPosition = rectTransform.position;

        // Устанавливаем объект в слой для перетаскивания
        transform.SetParent(dragLayer, false);
    }

    public void OnDrag(PointerEventData eventData) 
    {
        // Берем точку под пальцем
        Vector3 pointerPosition = eventData.position;
        // Перемещаем объект
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

    /// <summary>
    /// Проверяем пересекаются ли два объекта
    /// </summary>
    /// <returns></returns>
    private bool IsOverLapping()
    {
        foreach (RectTransform t in objects) 
        { 
            if(t == null || t == rectTransform || !t.gameObject.activeInHierarchy)
            {
                continue;
            }

            if(rectTransform.Overlaps(t))
            {
                return true;
            }
        }
        return false;
    }
}
