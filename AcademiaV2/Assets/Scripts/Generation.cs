using UnityEngine;
using UnityEngine.UI;

public class Generation : MonoBehaviour
{
    [SerializeField] private Image[] images;
    [SerializeField] private Sprite[] sprites;

    private void Start()
    {
        Refresh();
    }

    private void Refresh()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            int randIndex = Random.Range(0, images.Length);
            (sprites[i], sprites[randIndex]) = (sprites[randIndex], sprites[i]);
        }

        for (int i = 0;i < images.Length;i++)
        {
            images[i].sprite = sprites[i];
        }
    }
}
