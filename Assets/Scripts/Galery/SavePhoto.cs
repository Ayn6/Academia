using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SavePhoto : MonoBehaviour
{
    public Transform galleryContainer; // Контейнер для галереи (например, для отображения миниатюр)
    private List<Sprite> screenshots = new List<Sprite>(); // Список для хранения скриншотов
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
        // Ждем конца кадра, чтобы UI тоже попал в скрин
        yield return new WaitForEndOfFrame();

        // Создаем текстуру для скриншота
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        // Создаем спрайт и добавляем его в список
        Sprite screenshotSprite = Sprite.Create(screenshot, new Rect(0, 0, screenshot.width, screenshot.height), new Vector2(0.5f, 0.5f));
        screenshots.Add(screenshotSprite);

        // Сохраняем скриншот на диск
        SaveScreenshotToGallery(screenshot);

        // Обновляем галерею
        UpdateGallery();
    }

    private void SaveScreenshotToGallery(Texture2D screenshot)
    {
        string path = Path.Combine(Application.persistentDataPath, "screenshot_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");

        // Сохраняем файл как PNG
        byte[] screenshotBytes = screenshot.EncodeToPNG();
        File.WriteAllBytes(path, screenshotBytes);

        // Выводим путь для отладки
        Debug.Log("Screenshot saved at: " + path);

        // Для Android нужно использовать методы, чтобы гарантировать добавление в галерею
#if UNITY_ANDROID
        AddToGallery(path);
#endif
    }

#if UNITY_ANDROID
    private void AddToGallery(string path)
    {
        string fileUri = "file://" + path;

        // Получаем активность из Unity
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        // Используем MediaScannerConnection для сканирования файла
        AndroidJavaClass mediaScanner = new AndroidJavaClass("android.media.MediaScannerConnection");
        mediaScanner.CallStatic("scanFile", currentActivity, new string[] { fileUri }, null, null);
    }
#endif

    private void UpdateGallery()
    {
        // Очищаем старые элементы в галерее
        foreach (Transform child in galleryContainer)
        {
            Destroy(child.gameObject);
        }

        // Создаем элементы UI для каждого скриншота без использования префабов
        foreach (Sprite screenshot in screenshots)
        {
            // Создаем новый объект UI для скриншота
            GameObject screenshotItem = new GameObject("ScreenshotItem");
            screenshotItem.transform.SetParent(galleryContainer); // Устанавливаем родителя (контейнер для галереи)

            // Добавляем компонент Image и назначаем спрайт
            Image screenshotImage = screenshotItem.AddComponent<Image>();
            screenshotImage.sprite = screenshot;

            // Дополнительно, можно добавить размеры или отступы для изображений
            RectTransform rectTransform = screenshotItem.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(100, 100); // Устанавливаем размер изображения

            // Добавляем отступы или разметку
            screenshotImage.rectTransform.anchoredPosition = new Vector2(0, 0);

            // Если нужно управлять позиционированием, можно добавить логики для организации расположения изображений
        }
    }
}
