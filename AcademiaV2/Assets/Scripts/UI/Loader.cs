using TMPro;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private RectTransform rect;
    [SerializeField] private TextMeshProUGUI loadProcent;
    [SerializeField] private GameObject loaderScreen, mainScreen;
    private float procent;

    private void Start()
    {
        rect.localScale = new Vector3(0, 1, 1);    
    }
    private void Update()
    {
        if(procent >= 10000)
        {
            loaderScreen.SetActive(false);
            mainScreen.SetActive(true);
            return;
        }

        procent += 1;

        loadProcent.text = "Загрузка: " + Mathf.CeilToInt((procent / 100)).ToString() + "%";
        rect.localScale += new Vector3(0.0001f, 0, 0);
    }
}
