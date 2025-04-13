using System.Collections;
using UnityEngine;
using TMPro;

public class Loader : MonoBehaviour
{
    public RectTransform progressBar; // UI элемент (например, Image)
    public TextMeshProUGUI progressText; // Текстовый объект для процента загрузки
    private float progress = 0f;

    [SerializeField] private GameObject screen, screen2;

    void Start()
    {
        StartCoroutine(SimulateLoading());
    }

    IEnumerator SimulateLoading()
    {
        while (progress < 1f)
        {
            progress += 0.01f; // Увеличиваем загрузку
            UpdateProgressBar(progress);
            yield return new WaitForSeconds(0.05f); // Задержка для эффекта анимации
        }

        screen.SetActive(false);
        screen2.SetActive(true);
    }

    void UpdateProgressBar(float value)
    {
        progressBar.localScale = new Vector3(value, 1, 1); // Меняем scale только по X
        progressText.text = $"Загрузка: {Mathf.RoundToInt((value * 100)-1)}%"; // Обновляем текст
    }
}
