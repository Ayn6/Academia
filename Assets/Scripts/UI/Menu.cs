using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menu; // Объект меню (например, панель)
    public Image buttonImage; // Картинка на кнопке для смены спрайта
    public Sprite openSprite; // Спрайт для открытого состояния
    public Sprite closeSprite; // Спрайт для закрытого состояния

    private bool isMenuOpen = false; // Состояние меню (открыто или закрыто)

    // Метод для переключения состояния меню
    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen; // Переключаем состояние

        if (isMenuOpen)
        {
            // Открываем меню
            menu.SetActive(true); // Активируем меню
            buttonImage.sprite = closeSprite; // Меняем спрайт кнопки на "закрыть"
        }
        else
        {
            // Закрываем меню
            menu.SetActive(false); // Деактивируем меню
            buttonImage.sprite = openSprite; // Меняем спрайт кнопки на "открыть"
        }
    }
}
