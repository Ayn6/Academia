using System.Collections;
using UnityEngine;

public class CheckLogoAndCompany : MonoBehaviour
{
    public int selectedNameCompany;
    public int selectedLogoCompany;

    private LogoCompanyView logoCompanyView;
    private LogoCompanyView nameCompanyView;

    private int currentCountPair = 0;
    private int totalCountPair = 5;

    [SerializeField] private Timer timer;

    public void SelectName(LogoCompanyView nameCompany)
    {
        selectedNameCompany = nameCompany.nameCompanyIndex;
        nameCompanyView = nameCompany;

        nameCompany.ChangeOutline(Color.yellow, true);
    }

    public void SelectLogo(LogoCompanyView logoCompany)
    {
        selectedLogoCompany = logoCompany.logoCompanyIndex;
        logoCompanyView = logoCompany;

        if (logoCompanyView == null) { return; }

        if(selectedLogoCompany == selectedNameCompany)
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
