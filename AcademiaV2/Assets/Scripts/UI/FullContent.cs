using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FullContent : MonoBehaviour
{
    [SerializeField] private Image cover;
    [SerializeField] private TextMeshProUGUI title, descriptions;
    [SerializeField] private GameObject linkOnGame;
    [SerializeField] private GameObject[] linksWindows;

    private string currentTag;
    public void Full(Speciality speciality)
    {
        linkOnGame.SetActive(true);

        cover.sprite = speciality.cover;
        title.text = speciality.name;
        descriptions.text = speciality.description;

        if(speciality.countGames == 1)
        {
            linkOnGame.SetActive(false);
        }

        currentTag = speciality.tag;
    }

    public void OpenGame()
    {
        foreach (GameObject link in linksWindows) 
        {
            if(link.name == currentTag)
            {
                link.SetActive(true);
            }
        }
    }

    public void OpenGameForOtherLink()
    {
        if(currentTag == "Coloring")
        {
            linksWindows[1].SetActive(true);
        }
        else
        {
            linksWindows[4].SetActive(true);
        }
    }
}
