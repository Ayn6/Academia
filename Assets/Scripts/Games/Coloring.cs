using UnityEngine;
using UnityEngine.UI;

public class Coloring : MonoBehaviour
{
    private Color m_Color;
    private int indexIm;
    private int indexCol;
    private int count = 0;

    [SerializeField] private GameObject btn;
    public void GetColor(Image color)
    {
       indexCol = color.transform.GetSiblingIndex();
       m_Color = color.color;
    }

    public void GetNumber(int index)
    {
        indexIm = index;
        Debug.Log(indexIm);
    }

    public void SetColor(Image image)
    {        

        if(indexCol == indexIm && m_Color != null)
        {
            if (image.color == Color.white)
            {
                count++;
                if(count == 18)
                {
                    btn.SetActive(true);
                }
            }
            image.color = m_Color;
            indexIm = -1;
            Debug.Log(indexIm);
        }

        return;
    }
}
