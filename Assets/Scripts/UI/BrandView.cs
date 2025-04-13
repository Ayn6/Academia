using UnityEngine;
using UnityEngine.UI;

public class BrandView : MonoBehaviour
{
    public Brand brand; // ScriptableObject
    public Outline outline;

    public void SetOutline(Color color, bool enabled)
    {
        if (outline != null)
        {
            outline.effectColor = color;
            outline.enabled = enabled;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
