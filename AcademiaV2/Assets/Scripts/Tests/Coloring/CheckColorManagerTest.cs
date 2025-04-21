using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorTest
{
    private ColorManeger script;
    private Image paletteImage;
    private Image targetElement;

    [SetUp]
    public void Setup()
    {
        var go = new GameObject();
        script = go.AddComponent<ColorManeger>(); // замените на им€ вашего класса

        // »митируем палитру и элемент
        paletteImage = new GameObject().AddComponent<Image>();
        paletteImage.color = Color.red;

        targetElement = new GameObject().AddComponent<Image>();
        targetElement.color = Color.white;

        // Ёмул€ци€ индексов
        script.GetIndexElement(3);
    }

    [Test]
    public void ColorMatchesAfterSetColor()
    {
        script.GetColor(paletteImage);
// ”станавливаем текущий цвет
        script.SetColor(targetElement);

        Assert.AreEqual(Color.red, targetElement.color); // ѕроверка соответстви€
    }
}
