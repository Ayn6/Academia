using UnityEngine;
using UnityEngine.UI;

public class RandomMan : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Picture[] mans;

    public Picture currentMan;

    private void Start()
    {
        Refresh();
    }

    private void Refresh()
    {
        int randIndex = Random.Range(0, mans.Length);
        image.sprite = mans[randIndex].man;
        currentMan = mans[randIndex];
    }
}
