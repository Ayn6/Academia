using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileSetting : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameField;
    [SerializeField] private Image[] avatars;

    [SerializeField] private Sprite[] avatarsSpr;
    [SerializeField] private Sprite[] avatarsSelected;

    [SerializeField] protected StartGame full;

    private int indexAva = -1;
    private int previousIndex = -1;

    public void SaveProfile()
    {
        Player.NICKNAME = nicknameField.text;
        PlayerPrefs.SetString("PlayerName", nicknameField.text);

        Player.INDEX = indexAva;
        PlayerPrefs.SetInt("Index", indexAva);

        full.FullProfile();
    }

    public void GetIndex(int index)
    {
        indexAva = index;
    }

    public void SelectAvatar()
    {
        if (previousIndex == indexAva)
        {
            avatars[indexAva].sprite = avatarsSpr[indexAva];
            previousIndex = -1;
        }
        else
        {
            if (previousIndex != -1)
            {
                avatars[previousIndex].sprite = avatarsSpr[previousIndex];
            }


            avatars[indexAva].sprite = avatarsSelected[indexAva];
            previousIndex = indexAva;
        }
    }
}
