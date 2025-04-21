using UnityEngine;
using UnityEngine.EventSystems;

public class CreateClone : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform dragParent; // ��������, Canvas
    [SerializeField] private GameObject prefabToClone; // ������ �������� �������

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject clone = Instantiate(prefabToClone, dragParent);
        RectTransform cloneRect = clone.GetComponent<RectTransform>();

        // ������������� ���� � ����� dragParent
        cloneRect.anchoredPosition = Vector2.zero;

        // �������� ������� � ������� (���� �����)
        RectTransform originalRect = GetComponent<RectTransform>();
        cloneRect.localScale = originalRect.localScale;
        cloneRect.sizeDelta = originalRect.sizeDelta;

        // ���������� ��������������, ���� ���� drag-������
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
