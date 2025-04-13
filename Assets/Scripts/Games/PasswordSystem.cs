using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordSystem : MonoBehaviour
{
    public TextMeshProUGUI displayText;       // Поле для ввода пароля (UI)
    public TextMeshProUGUI generatedText;     // Поле, где временно показывается пароль
    public GameObject numberPad;   // Виртуальная клавиатура
    public Image inputBackground;  // Фон поля для подсветки

    private string generatedPassword;
    private string userInput = "";
    private bool canInput = false;

    public RectTransform passwordBox; // Прямоугольник, где появляется пароль
    public Vector2 spawnAreaMin = new Vector2(-200, -300);
    public Vector2 spawnAreaMax = new Vector2(200, 300);

    public float timeLimit = 30f;
    private float timer;
    public TextMeshProUGUI timerText;

    private bool gameOver = false;

    [SerializeField] private GameObject screen1, screen2;

    private int count = 0;

    void Start()
    {        
        timer = timeLimit;
        displayText.text = "";
        StartCoroutine(GeneratePassword());
    }

    public void Timaer()
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
            GameOver(); // проигрыш
        }
    }


    IEnumerator GeneratePassword()
    {
        generatedPassword = Random.Range(100000, 999999).ToString(); // 4-значный пароль
        generatedText.text = generatedPassword;

        // Случайная позиция в пределах прямоугольной области
        Vector2 randomPos = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );
        passwordBox.anchoredPosition = randomPos;

        generatedText.gameObject.SetActive(true);
        passwordBox.gameObject.SetActive(true);
        canInput = false;

        yield return new WaitForSeconds(2f);

        generatedText.gameObject.SetActive(false);
        passwordBox.gameObject.SetActive(false);
        canInput = true;
        userInput = "";
        displayText.text = "";
    }

    public void AddNumber(string number)
    {
        if (!canInput) return;

        if (userInput.Length < 6) // Ограничиваем ввод 4 символами
        {
            userInput += number;
            displayText.text = userInput;
        }
    }

    public void ClearInput()
    {
        userInput = "";
        displayText.text = "";
    }

    public void SubmitPassword()
    {
        if (!canInput) return;

        if (userInput == generatedPassword)
        {
            inputBackground.color = Color.green;
            StartCoroutine(NextRound());

        }
        else
        {
            inputBackground.color = Color.red;
            StartCoroutine(WrongPassword());
        }        
        count++;

        if(count == 5)
        {
            GameOver();
        }
        ClearInput();
    }

    IEnumerator WrongPassword()
    {
        yield return new WaitForSeconds(1f);
        inputBackground.color = new Color32(112, 115, 125, 255); ;

        StartCoroutine(GeneratePassword());
    }

    IEnumerator NextRound()
    {
        yield return new WaitForSeconds(1f);
        inputBackground.color = new Color32(112, 115, 125, 255); ;
        StartCoroutine(GeneratePassword());
    }

    private void GameOver()
    {
        gameOver = true;
        screen1.SetActive(false);
        screen2.SetActive(true);
    }
}
