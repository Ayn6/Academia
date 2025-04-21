using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordGame : MonoBehaviour
{
    [SerializeField] private GameObject password;
    [SerializeField] private TextMeshProUGUI passwordText;
    [SerializeField] private TextMeshProUGUI input;
    [SerializeField] private Image image;

    [SerializeField] private Timer timer;

    private int currentPassword;
    public int maxX, minX, maxY, minY;
    private int setCountPassword = 0;
    private int totalCountPassword = 5;

    private void Start()
    {
      StartCoroutine(ChangePassword());
    }

    public IEnumerator ChangePassword()
    {
        password.SetActive(true);
        currentPassword = Random.Range(100000, 999999);
        passwordText.text = currentPassword.ToString();

        int randPosX = Random.Range(minX, maxX);
        int randPosY = Random.Range(minY, maxY);

        password.transform.position = new Vector2 (randPosX, randPosY);

        yield return new WaitForSeconds(2f);

        password.SetActive(false);
    }

    public void InputNumber(string number)
    {
        if(input.text.Length < 6)
        {
            input.text += number;
        }
    }

    public void ClearInut()
    {
        input.text = "";
    }

    public void SendPassword()
    {
        if(input.text == currentPassword.ToString())
        {
            StartCoroutine(ChangeColor(true));
        } 
        else
        {
            StartCoroutine(ChangeColor(false));
        }

        StartCoroutine(ChangePassword());
    }

    private IEnumerator ChangeColor(bool right)
    {
        if(right)
        {
            image.color = Color.green;
        }
        else
        {
            image.color = Color.red;
        }

        yield return new WaitForSeconds(2f);
        ClearInut();
        image.color = Color.grey;
        setCountPassword++;
        if (setCountPassword == totalCountPassword)
        {
            timer.GameOver();
        }
    }
}
