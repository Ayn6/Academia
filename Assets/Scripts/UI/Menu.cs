using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menu; // ������ ���� (��������, ������)
    public Image buttonImage; // �������� �� ������ ��� ����� �������
    public Sprite openSprite; // ������ ��� ��������� ���������
    public Sprite closeSprite; // ������ ��� ��������� ���������

    private bool isMenuOpen = false; // ��������� ���� (������� ��� �������)

    // ����� ��� ������������ ��������� ����
    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen; // ����������� ���������

        if (isMenuOpen)
        {
            // ��������� ����
            menu.SetActive(true); // ���������� ����
            buttonImage.sprite = closeSprite; // ������ ������ ������ �� "�������"
        }
        else
        {
            // ��������� ����
            menu.SetActive(false); // ������������ ����
            buttonImage.sprite = openSprite; // ������ ������ ������ �� "�������"
        }
    }
}
