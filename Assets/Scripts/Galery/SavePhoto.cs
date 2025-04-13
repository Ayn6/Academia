using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SavePhoto : MonoBehaviour
{
    public Transform galleryContainer; // ��������� ��� ������� (��������, ��� ����������� ��������)
    private List<Sprite> screenshots = new List<Sprite>(); // ������ ��� �������� ����������
    public GameObject d;

    private void Start()
    {
        galleryContainer = GameObject.FindWithTag("Galery").transform;
        d.SetActive(false);
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    }

    public void TakeScreenshot()
    {
        StartCoroutine(CaptureScreenshot());
    }

    private IEnumerator CaptureScreenshot()
    {
        // ���� ����� �����, ����� UI ���� ����� � �����
        yield return new WaitForEndOfFrame();

        // ������� �������� ��� ���������
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        // ������� ������ � ��������� ��� � ������
        Sprite screenshotSprite = Sprite.Create(screenshot, new Rect(0, 0, screenshot.width, screenshot.height), new Vector2(0.5f, 0.5f));
        screenshots.Add(screenshotSprite);

        // ��������� �������� �� ����
        SaveScreenshotToGallery(screenshot);

        // ��������� �������
        UpdateGallery();
    }

    private void SaveScreenshotToGallery(Texture2D screenshot)
    {
        string path = Path.Combine(Application.persistentDataPath, "screenshot_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");

        // ��������� ���� ��� PNG
        byte[] screenshotBytes = screenshot.EncodeToPNG();
        File.WriteAllBytes(path, screenshotBytes);

        // ������� ���� ��� �������
        Debug.Log("Screenshot saved at: " + path);

        // ��� Android ����� ������������ ������, ����� ������������� ���������� � �������
#if UNITY_ANDROID
        AddToGallery(path);
#endif
    }

#if UNITY_ANDROID
    private void AddToGallery(string path)
    {
        string fileUri = "file://" + path;

        // �������� ���������� �� Unity
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        // ���������� MediaScannerConnection ��� ������������ �����
        AndroidJavaClass mediaScanner = new AndroidJavaClass("android.media.MediaScannerConnection");
        mediaScanner.CallStatic("scanFile", currentActivity, new string[] { fileUri }, null, null);
    }
#endif

    private void UpdateGallery()
    {
        // ������� ������ �������� � �������
        foreach (Transform child in galleryContainer)
        {
            Destroy(child.gameObject);
        }

        // ������� �������� UI ��� ������� ��������� ��� ������������� ��������
        foreach (Sprite screenshot in screenshots)
        {
            // ������� ����� ������ UI ��� ���������
            GameObject screenshotItem = new GameObject("ScreenshotItem");
            screenshotItem.transform.SetParent(galleryContainer); // ������������� �������� (��������� ��� �������)

            // ��������� ��������� Image � ��������� ������
            Image screenshotImage = screenshotItem.AddComponent<Image>();
            screenshotImage.sprite = screenshot;

            // �������������, ����� �������� ������� ��� ������� ��� �����������
            RectTransform rectTransform = screenshotItem.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(100, 100); // ������������� ������ �����������

            // ��������� ������� ��� ��������
            screenshotImage.rectTransform.anchoredPosition = new Vector2(0, 0);

            // ���� ����� ��������� �����������������, ����� �������� ������ ��� ����������� ������������ �����������
        }
    }
}
