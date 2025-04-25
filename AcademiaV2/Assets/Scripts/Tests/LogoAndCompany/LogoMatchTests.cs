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
        LogoCompanyView name = new GameObject().AddComponent<LogoCompanyView>();
        name.nameCompanyIndex = 1;

        LogoCompanyView logo = new GameObject().AddComponent<LogoCompanyView>();
        logo.logoCompanyIndex = 1;
    }

    [Test]
    public void SelectLogo_CorrectMatch_ShouldChangeOutlineToGreen()
    {
        

        matchManager.SelectName(name);
        matchManager.SelectLogo(logo);

        Assert.AreEqual(true, matchManager.selectedLogoCompany == matchManager.selectedNameCompany);

    }

}
