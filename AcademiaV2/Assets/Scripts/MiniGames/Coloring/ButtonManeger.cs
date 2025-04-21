using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManeger : MonoBehaviour
{
    public float alphaThreshold = 0.1f;

    private void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = alphaThreshold;
    }
}
