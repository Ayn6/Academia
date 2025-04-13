using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject settingWindow;

    [SerializeField] private TextMeshProUGUI nick;
    [SerializeField] private Image avatar;

    [SerializeField] private Player player;

    private void Start()
    {

        string nickname = PlayerPrefs.GetString("PlayerName");
        if (!string.IsNullOrEmpty(nickname))
        {
            Player.NICKNAME = nickname;

            int indexAva = PlayerPrefs.GetInt("Index");
            Player.INDEX = indexAva;

            FullProfile();
            settingWindow.SetActive(false);
        }
    }

    public void FullProfile()
    {
        nick.text = Player.NICKNAME;
        avatar.sprite = player.avatars[Player.INDEX];
    }
}
