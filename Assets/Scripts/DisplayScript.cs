using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _character;
    [SerializeField]
    private GameObject _coin;
    [SerializeField]
    private TMPro.TextMeshProUGUI _textDistance;

    const float neutralDistance = 7f; // ������� �� ������ � �������� ������

    void Start()
    {
        
    }

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
    }
}
/* ���������� ��������� ��������� ������: �� ����� 10 � �� ������ 20 �� ���������
 * (�������� �������� �������� �����������)
 * �������������� ����� �� ������� ���� (���)
 * ** �������������� ������ ��������� ������ �� ������ ����� � ������ �����
 * * ���� ������ ��������� � �������� (�������, ����,...), �� ������������
 */