using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Player", menuName = "Data/Player")]
public class Player : ScriptableObject
{
    public static string NICKNAME;
    public static int INDEX;
    public Sprite[] avatars;
}
