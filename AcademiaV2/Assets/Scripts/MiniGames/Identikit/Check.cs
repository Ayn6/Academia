using UnityEngine;
using UnityEngine.UI;

public class Check : MonoBehaviour
{
    [SerializeField] private RandomMan randomMan;
    [SerializeField] private Image currentFace, currentHair, currentEye, currentNose, currentLips, cerrentBread, currentGalsses;

    public void CompereFace()
    {
        Picture currentMan = randomMan.currentMan;
        ComperePart(currentFace, currentMan.face);
        ComperePart(currentHair, currentMan.hair);
        ComperePart(currentEye, currentMan.eye);
        ComperePart(currentNose, currentMan.nose);
        ComperePart(currentLips, currentMan.lips);
        ComperePart(cerrentBread, currentMan.beard);
        ComperePart(currentGalsses, currentMan.glassws);
    }           

    public void ComperePart(Image currentValue, Sprite rightValue)
    {
        if(currentValue.sprite != null)
        {                
            Outline outline = currentValue.GetComponent<Outline>(); 
            if(currentValue.sprite == rightValue)
            {

                outline.effectColor = Color.green;
            }
            else
            {
                outline.effectColor = Color.red;
            }
        }
    }
}
