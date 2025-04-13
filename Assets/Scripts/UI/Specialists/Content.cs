using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Content : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;

    [SerializeField] private Image cover;
    [SerializeField] private Image dopEx;

    private Spetial spetialy;

    public void FullContet(Spetial spetial)
    {
        dopEx.enabled = true;

        cover.sprite = spetial.cover;
        title.text = spetial.name;
        description.text = spetial.description;

        if(spetial.linkDop == "")
        {
            dopEx.enabled = false;
        }

        spetialy = spetial;
    }

    public void OpenGame(int index)
    {
        string link;
        if(index == 1)
        {
            link = spetialy.linkDop;
        }
        else
        {
            link = spetialy.link;
        }
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag(
                link))
            {
                obj.SetActive(true);
                break;
            }
        }


    }
}
