using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Image timerBoard;

    [SerializeField] private GameObject gameScreen, specilitiesScreen;

    public float time;

    private void Start()
    {
        timerBoard.color = Color.green;
        timerBoard.fillAmount = 1;
    }

    private void Update()
    {        
        if(time <= 0)
        {
            GameOver();
        }

        if(timerBoard.color == Color.green && time <= 10)
        {
            timerBoard.color = Color.red;
        }

        time -= Time.deltaTime;
        timerText.text = Mathf.CeilToInt(time).ToString();
        timerBoard.fillAmount -= Time.deltaTime / 30;
    }

    public void GameOver()
    {
        gameScreen.SetActive(false);
        specilitiesScreen.SetActive(true);
    }
}
