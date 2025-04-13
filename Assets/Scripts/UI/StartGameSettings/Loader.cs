using System.Collections;
using UnityEngine;
using TMPro;

public class Loader : MonoBehaviour
{
    public RectTransform progressBar; // UI ������� (��������, Image)
    public TextMeshProUGUI progressText; // ��������� ������ ��� �������� ��������
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
            progress += 0.01f; // ����������� ��������
            UpdateProgressBar(progress);
            yield return new WaitForSeconds(0.05f); // �������� ��� ������� ��������
        }

        screen.SetActive(false);
        screen2.SetActive(true);
    }

    void UpdateProgressBar(float value)
    {
        progressBar.localScale = new Vector3(value, 1, 1); // ������ scale ������ �� X
        progressText.text = $"��������: {Mathf.RoundToInt((value * 100)-1)}%"; // ��������� �����
    }
}
