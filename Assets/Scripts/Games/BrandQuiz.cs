using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BrandQuiz : MonoBehaviour
{
    public BrandClue[] clues;             // массив фраз и названий
    public TextMeshProUGUI phraseText;               // UI Text для отображения фразы
    public TMP_InputField answerInput;        // поле ввода
    public Outline inputBackground;         // фон поля для подсветки

    private int currentIndex = 0;
    private bool canAnswer = true;

    public float timeLimit = 30f;
    private float timer;
    public TextMeshProUGUI timerText;

    private bool gameOver = false;

    [SerializeField] private GameObject screen1, screen2;

    void Start()
    {
        ShuffleClues(); // 🎯 Перемешиваем массив
        timer = timeLimit;
        ShowCurrentPhrase();
    }

    void ShuffleClues()
    {
        for (int i = 0; i < clues.Length; i++)
        {
            int randIndex = Random.Range(i, clues.Length);
            (clues[i], clues[randIndex]) = (clues[randIndex], clues[i]);
        }
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
            GameOver(); // проигрыш
        }
    }

    void ShowCurrentPhrase()
    {
        if (currentIndex >= clues.Length)
        {
            GameOver();
            answerInput.interactable = false;
            return;
        }

        phraseText.text = clues[currentIndex].phrase;
        answerInput.text = "";
        inputBackground.effectColor = new Color32(85, 74, 233, 255);
        canAnswer = true;
    }

    public void OnSubmitAnswer()
    {
        if (!canAnswer) return;

        string userInput = answerInput.text.Trim().ToLower();
        string correctAnswer = clues[currentIndex].brandName.Trim().ToLower();

        if (userInput == correctAnswer)
        {
            inputBackground.effectColor = Color.green;
            canAnswer = false;
            StartCoroutine(NextClueAfterDelay());
        }
        else
        {
            inputBackground.effectColor = Color.red;
            StartCoroutine(NextClueAfterDelay());
        }
    }

    IEnumerator NextClueAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        currentIndex++;
        ShowCurrentPhrase();
    }

    private void GameOver()
    {
        gameOver = true;
        screen1.SetActive(false);
        screen2.SetActive(true);
    }
}
