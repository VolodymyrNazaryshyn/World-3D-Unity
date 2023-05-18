using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject _menuContent;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = _menuContent.activeInHierarchy ? 1.0f : 0.0f;
            _menuContent.SetActive(! _menuContent.activeInHierarchy);
        }
    }
}
// Скрипты на неактивном объекте не исполняются
/* * Д.З. Реализовать элластичный дизайн игрового меню - адаптивность
 * к разным размерам и пропорциям экрана.
 * ** добавить в меню блоки настроек "Сложность" (показывать расстояние до монеты,
 *    дальность спавна, ...)
 *    блок "Звук" - громкость (звук, эффекты) и общее выключение
 */