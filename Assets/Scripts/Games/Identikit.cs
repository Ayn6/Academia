using UnityEngine;
using UnityEngine.UI;

public class Identikit : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Image imageR;

    public void Change()
    {
        imageR.sprite = image.sprite;
    }
}
