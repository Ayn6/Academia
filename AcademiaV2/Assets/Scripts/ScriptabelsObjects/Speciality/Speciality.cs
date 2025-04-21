using UnityEngine;

[CreateAssetMenu(fileName = "Speciality", menuName = "Specialities/Speciality")]

public class Speciality : ScriptableObject
{
    public Sprite cover;
    public string name;
    public string description;
    public int countGames;
    public string tag;
}
