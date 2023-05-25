using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject _menuContent;

    void Start()
    {
        GameSettings.LoadSettings();
        GameObject.Find("MuteToggle").GetComponent<Toggle>().isOn = GameSettings.IsMuted;
        GameObject.Find("BgSlider").GetComponent<Slider>().value = GameSettings.BackgroundVolume;
        
        Time.timeScale = _menuContent.activeInHierarchy ? 0.0f : 1.0f;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = _menuContent.activeInHierarchy ? 1.0f : 0.0f;
            _menuContent.SetActive(! _menuContent.activeInHierarchy);
        }
    }

    /********  UI Event Handlers ********/
    public void MuteChanged(bool state)
    {
        // Debug.Log(state);
        GameSettings.IsMuted = state;
    }
    public void BackgroundVolumeChanged(Single value)
    {
        GameSettings.BackgroundVolume = value;
    }
}
// Скрипты на неактивном объекте не исполняются
/* * Д.З. Реализовать элластичный дизайн игрового меню - адаптивность
 * к разным размерам и пропорциям экрана.
 * ** добавить в меню блоки настроек "Сложность" (показывать расстояние до монеты,
 *    дальность спавна, ...)
 *    блок "Звук" - громкость (звук, эффекты) и общее выключение
 */