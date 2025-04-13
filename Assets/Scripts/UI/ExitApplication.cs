using UnityEngine;

public class ExitApplication : MonoBehaviour
{
    public void Exit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
