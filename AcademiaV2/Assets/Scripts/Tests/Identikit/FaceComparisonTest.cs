using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class FaceComparisonTest : MonoBehaviour
{
    private GameObject testObj;
    private Image testImage;
    private Outline outline;

    private Sprite correctSprite;
    private Sprite wrongSprite;

    private Check comparer;

    [SetUp]
    public void Setup()
    {
        // ������ ������ � Image � Outline
        testObj = new GameObject("TestImage");
        testImage = testObj.AddComponent<Image>();
        outline = testObj.AddComponent<Outline>();

        Texture2D tex1 = new Texture2D(16, 16); // ������ ������ 10x10
        Texture2D tex2 = new Texture2D(16, 16);

        correctSprite = Sprite.Create(tex1, new Rect(0, 0, 10, 10), Vector2.zero);
        wrongSprite = Sprite.Create(tex2, new Rect(0, 0, 10, 10), Vector2.zero);

        // ������ �������� ����� � ������� ComperePart
        comparer = new Check();
    }

    [Test]
    public void ComparePart_CorrectSprite_ColorIsGreen()
    {
        testImage.sprite = correctSprite;
        comparer.ComperePart(testImage, correctSprite);
        Assert.AreEqual(Color.green, outline.effectColor);
    }

    [Test]
    public void ComparePart_WrongSprite_ColorIsRed()
    {
        testImage.sprite = wrongSprite;
        comparer.ComperePart(testImage, correctSprite);
        Assert.AreEqual(Color.red, outline.effectColor);
    }
}
