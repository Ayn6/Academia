using UnityEngine;
using UnityEngine.UI;

public class CollectFace : MonoBehaviour
{
    [SerializeField] private Image image;
    public void ChangePert(Image part)
    {
        Color c = Color.black;
        c.a = 1;
        image.color = c;
        image.sprite = part.sprite;
    }

}
