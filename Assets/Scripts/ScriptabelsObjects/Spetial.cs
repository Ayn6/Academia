using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Spetial", menuName = "Data/Spetial")]
public class Spetial : ScriptableObject
{
    public Sprite cover;
    public string name;
    public string description;
    public float reiting;
    public int gameCount;
    public string link, linkDop;
}
