using UnityEngine;
using UnityEngine.UI;

public class ColorManeger : MonoBehaviour
{
    private Color currentColor;
    private int indexColor, indexElement;
    private int count;

    [SerializeField] private GameObject button;

    public void GetColor(Image color)
    {
        currentColor = color.color;
        indexColor = color.transform.GetSiblingIndex() + 1;
    }

    public void SetColor(Image element)
    {
        if (indexColor == indexElement)
        {
            if(element.color == Color.white)
            {
                count++;
            }
            Coloring(element);
        }

        if (count >= 18)
        {
            button.SetActive(true);
        }
        return;
    }

    public void Coloring(Image element)
    {
        if(currentColor != null)
        {
            currentColor.a = 1;
            element.color = currentColor;
        }

    }

    public void GetIndexElement(int index)
    {
        indexElement = index;
    }

    public void OffsetColor()
    {
        currentColor = Color.black;
    }
}
