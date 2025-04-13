using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Brands : MonoBehaviour
{

    private Brand selectedBrandLogo;
    private BrandView selectedLogoView;

    private Brand selectedBrandName;
    private BrandView selectedNameView;

    private int matchedCount = 0;
    public int totalPairs = 9;

    public float timeLimit = 30f;
    private float timer;
    private bool gameOver = false;

    public GameObject gameOverPanel, screen; // ������, ������� ���������� � ����� 
    public TextMeshProUGUI timerText;

    void Start()
    {
        timer = timeLimit;
    }

    void Update()
    {
        if (gameOver) return;

        timer -= Time.deltaTime;
        if (timerText != null)
        {
            timerText.text = $"{Mathf.CeilToInt(timer)}";
        }

        if (timer <= 0f)
        {
            GameOver(); // ��������
        }
    }

    public void SelectLogo(BrandView logoView)
    {
        selectedBrandName = logoView.brand;
        selectedNameView = logoView;

        if (selectedBrandLogo == null) return;

        if (selectedBrandLogo == selectedBrandName)
        {
            // ���������� � ������ ��������� � ������������
            selectedLogoView.SetOutline(Color.green, true);
            selectedNameView.SetOutline(Color.green, true);
            StartCoroutine(HideAfterDelay(selectedLogoView, selectedNameView));
        }
        else
        {
            // ������ � ������� ���������
            selectedLogoView.SetOutline(Color.red, true);
            selectedNameView.SetOutline(Color.red, true);
            StartCoroutine(ClearSelectionAfterDelay());
        }

    }
    // ������ ������ ��������
    public void SelectName(BrandView nameView)
    {
        selectedBrandLogo = nameView.brand;
        selectedLogoView = nameView;

        nameView.SetOutline(Color.yellow, true); // ��������� ��������� ���������� ��������
    }
    private IEnumerator HideAfterDelay(BrandView logo, BrandView name)
    {
        yield return new WaitForSeconds(0.5f);
        logo.Hide();
        name.Hide();

        matchedCount++;

        if (matchedCount >= totalPairs)
        {
            GameOver(); // ������
        }

        ClearSelection();
    }

    private IEnumerator ClearSelectionAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        selectedLogoView.SetOutline(Color.clear, false);
        selectedNameView.SetOutline(Color.clear, false);
        ClearSelection();
    }

    private void ClearSelection()
    {
        selectedBrandLogo = null;
        selectedBrandName = null;
        selectedLogoView = null;
        selectedNameView = null;
    }

    private void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(false);
        screen.SetActive(true);
    }
}
