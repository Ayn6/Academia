using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LogoMatchTests : MonoBehaviour
{
    private GameObject gameObject;
    private CheckLogoAndCompany matchManager;

    [SetUp]
    public void Setup()
    {
        gameObject = new GameObject();
        matchManager = gameObject.AddComponent<CheckLogoAndCompany>();
    }

    // “ест на правильное совпадение индексов
    [Test]
    public void SelectLogo_CorrectMatch_ShouldChangeOutlineToGreen()
    {
        var name = new GameObject().AddComponent<LogoCompanyView>();
        name.nameCompanyIndex = 1;

        var logo = new GameObject().AddComponent<LogoCompanyView>();
        logo.logoCompanyIndex = 1;

        matchManager.SelectName(name);
        matchManager.SelectLogo(logo);

        Assert.AreEqual(true, matchManager.selectedLogoCompany == matchManager.selectedNameCompany);

    }

}
