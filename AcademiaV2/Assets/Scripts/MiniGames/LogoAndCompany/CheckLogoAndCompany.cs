using System.Collections;
using UnityEngine;

public class CheckLogoAndCompany : MonoBehaviour
{
    private LogoCompanyView logoCompanyView;
    private LogoCompanyView nameCompanyView;

    private int currentCountPair = 0;
    private int totalCountPair = 5;

    [SerializeField] private Timer timer;

    public void SelectName(LogoCompanyView nameCompany)
    {
        if (nameCompanyView == null) { return; }

        nameCompanyView = nameCompany;

        nameCompany.ChangeOutline(Color.yellow, true);
    }

    public void SelectLogo(LogoCompanyView logoCompany)
    {
        if (nameCompanyView == null) { return; }

        logoCompanyView = logoCompany;


        if(logoCompanyView.index == selectedNameCompany)
        {
            nameCompanyView.ChangeOutline(Color.green, true);
            logoCompanyView.ChangeOutline(Color.green, true);
            StartCoroutine(HideAfterDeplay());
        }
        else
        {
            nameCompanyView.ChangeOutline(Color.red, true);
            logoCompanyView.ChangeOutline(Color.red, true);
            StartCoroutine(ClearSelectionAfterDeplay());
        }
    }

    private IEnumerator ClearSelectionAfterDeplay()
    {
        yield return new WaitForSeconds(1);

        nameCompanyView.ChangeOutline(Color.black, false);
        logoCompanyView.ChangeOutline(Color.black, false);
    }

    private IEnumerator HideAfterDeplay()
    {
        yield return new WaitForSeconds(1);

        nameCompanyView.Hide();
        logoCompanyView.Hide();

        currentCountPair++;

        if(totalCountPair == currentCountPair)
        {
            timer.GameOver();
        }
    }
}
