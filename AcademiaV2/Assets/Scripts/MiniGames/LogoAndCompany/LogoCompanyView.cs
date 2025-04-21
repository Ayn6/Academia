using UnityEngine;
using UnityEngine.UI;

public class LogoCompanyView : MonoBehaviour
{
    public int nameCompanyIndex;
    public int logoCompanyIndex;

    [SerializeField] private Outline outline;

    public void ChangeOutline(Color color, bool enabel)
    {
        if (outline != null) 
        { 
            outline.effectColor = color;
            outline.enabled = enabel;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
