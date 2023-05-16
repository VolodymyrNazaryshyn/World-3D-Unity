using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] private GameObject _coin;
    [SerializeField] private TMPro.TextMeshProUGUI _textDistance;
    [SerializeField] private TMPro.TextMeshProUGUI _coinCountText;

    public static int coinCount; // static для доступа к переменной из других скриптов

    const float neutralDistance = 7f; // переход от синего к красному тексту

    void Update()
    {
        float distance = Vector3.Distance(
            _character.transform.position,
            _coin.transform.position);

        _textDistance.text = distance.ToString("0.0");
        distance /= neutralDistance;
        _textDistance.color = new Color(
            1 / (1 + distance), 
            0.2f,
            distance / (1 + distance));

        _coinCountText.text = coinCount.ToString(); // изменяем coinCount
    }
}
/* Обеспечить случайное появление монеты: не ближе 10 и не дальше 20 от персонажа
 * (числовые значения задавать константами)
 * Контролировать выход за пределы мира (гор)
 * ** корректировать высоту появления монеты на высоту земли в данной точке
 * * если монета спавнится с колизией (деревья, горы,...), то переспавнить
 */