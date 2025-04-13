using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class General : MonoBehaviour
{
    [SerializeField] private Face[] faces;
    [SerializeField] private Image image;

    public Face face;

    public Color correctColor = Color.green;
    public Color incorrectColor = Color.red;    
    
    [Header("Собранное игроком")]
    public Image headImage;
    public Image eyesImage;
    public Image noseImage;
    public Image mouthImage;
    public Image hairImage;
    public Image glassesImage;
    public Image breadImage;

    [Header("Обводки/рамки")]
    public Outline headOutline;
    public Outline eyesOutline;
    public Outline noseOutline;
    public Outline mouthOutline;
    public Outline hairOutline;
    public Outline glassesOutline;
    public Outline breadOutline;

    [Header("Правильное лицо")]
    public Face correctFace;

    [SerializeField] private GameObject screen1, screen2;
    private void Start()
    {
        RandomFace();
    }

    public void RandomFace()
    {
        int index = Random.Range(0, faces.Length-1);
        image.sprite = faces[index].faceReady;
        correctFace =faces[index];
    }

    public void CheckFace()
    {
        CheckPart(headImage.sprite, correctFace.face, headOutline);
        CheckPart(eyesImage.sprite, correctFace.eye, eyesOutline);
        CheckPart(noseImage.sprite, correctFace.nose, noseOutline);
        CheckPart(mouthImage.sprite, correctFace.lips, mouthOutline);
        CheckPart(hairImage.sprite, correctFace.hair, hairOutline);
        CheckPart(glassesImage.sprite, correctFace.glassec, glassesOutline);
        CheckPart(breadImage.sprite, correctFace.bread, breadOutline);
    }

    private void CheckPart(Sprite current, Sprite correct, Outline outline)
    {
        if (outline == null) return;

        outline.enabled = true;
        outline.effectColor = (current == correct) ? correctColor : incorrectColor;
    }

    public void Change()
    {        

        StartCoroutine(Screen());

    }

    private IEnumerator Screen()
    {
        yield return new WaitForSeconds(5f);
        screen1.SetActive(true);
        screen2.SetActive(false);
    }
}
