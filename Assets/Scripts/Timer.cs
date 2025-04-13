using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject screen, screen1;

    private void Start()
    {
        StartCoroutine(Face());
    }

    private IEnumerator Face()
    {
        yield return new WaitForSeconds(30);
        Debug.Log(1);
        screen.SetActive(false);
        screen1.SetActive(true);
    }
}
