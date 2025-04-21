using NUnit.Framework;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhrasesGameTest : MonoBehaviour
{
    private GameObject gameObject;
    private GuessPhrase guessPhrase;

    [SetUp]
    public void SetUp()
    {
        gameObject = new GameObject();
        guessPhrase = gameObject.AddComponent<GuessPhrase>();

        // Подготовка фейковых данных
        var testPhrase = new Prases { phrase = "Some phrase", company = "Apple" };
        var field = typeof(GuessPhrase).GetField("phrases", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        field.SetValue(guessPhrase, new Prases[] { testPhrase });

        // Настройка UI
        guessPhrase.phraseText = new GameObject().AddComponent<TextMeshProUGUI>();
        guessPhrase.input = new GameObject().AddComponent<TMP_InputField>();
        guessPhrase.outline = new GameObject().AddComponent<Outline>();
        guessPhrase.timer = new GameObject().AddComponent<Timer>();

        // Принудительно установить currentIndex
        guessPhrase.GetType().GetField("currentIndex", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(guessPhrase, 0);
    }

    [Test]
    public void SentAnswer_IsCaseInsensitive()
    {
        guessPhrase.input.text = "apple"; // lower case
        guessPhrase.SentAnswer();
        Assert.IsTrue(guessPhrase.answerIsRight, "Lowercase answer should match");

        guessPhrase.input.text = "APPLE"; // upper case
        guessPhrase.SentAnswer();
        Assert.IsTrue(guessPhrase.answerIsRight, "Uppercase answer should match");

        guessPhrase.input.text = "ApPlE"; // mixed case
        guessPhrase.SentAnswer();
        Assert.IsTrue(guessPhrase.answerIsRight, "Mixed case answer should match");
    }
}
