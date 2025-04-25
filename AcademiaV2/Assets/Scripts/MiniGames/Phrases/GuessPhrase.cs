using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuessPhrase : MonoBehaviour
{
    [SerializeField] private Prases[] phrases;

    public TextMeshProUGUI phraseText;
    public TMP_InputField input;
    public Outline outline;

    public Timer timer;

    private int currentIndex;
    public bool answerIsRight;


    private void Start()
    {
        Refresh();
        ChangePhrase();
    }

    private void Shuffle()
    {
        for (int i = 0; i < phrases.Length; i++)
        {
            int randIndex = Random.Range(0, phrases.Length);
            (phrases[i], phrases[randIndex]) = (phrases[randIndex], phrases[i]);
        }
    }

    private void UpdatePhraseText()
    {
        phraseText.text = phrases[currentIndex].phrase;
    }

    public void SentAnswer()
    {
        string currentAnswer = input.text.Trim().ToLower();
        string currentCorrectAnswer = phrases[currentIndex].company.Trim().ToLower();
        answerIsRight = currentAnswer == currentCorrectAnswer;

        StartCoroutine(ChangeColor(answerIsRight));

    }

    private IEnumerator ChangeColor(bool right)
    {
        if (right)
        {
            outline.effectColor = Color.green;
        }
        else
        {
            outline.effectColor = Color.red;
        }

        yield return new WaitForSeconds(1f);

        input.text = "";
        outline.effectColor = Color.white;
        currentIndex++;        
        ChangePhrase();
        if (phrases.Length <= currentIndex)
        {
            timer.GameOver();
        }
    }
}
