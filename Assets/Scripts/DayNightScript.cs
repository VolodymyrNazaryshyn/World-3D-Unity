using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    [SerializeField] private Material daySkybox;
    [SerializeField] private Material nightSkybox;

    private Light _sun;  // Directional light 1
    private Light _moon; // Directional light 0.5

    private GameObject _lightElem;
    private GameObject _sunObj;
    private GameObject _moonObj;

    const float _fullDayTime = 30f;                // секунд на суточный цикл
    const float _deltaAngle = -360 / _fullDayTime; // угол поворота света за 1 с
    float _dayTime;                                // текущее время
    float _dayPhase;                               // фаза суток приведенная к диапазону [0..1]

    private AudioSource _daySound;
    private AudioSource _nightSound;

    void Start()
    {
        _sunObj = GameObject.Find("SunLight");
        _moonObj = GameObject.Find("MoonLight");

        _sun = GameObject.Find("SunLight").GetComponent<Light>();
        _moon = GameObject.Find("MoonLight").GetComponent<Light>();
        _lightElem = GameObject.Find("LightElem");

        AudioSource[] audioSources = this.GetComponents<AudioSource>();
        _daySound = audioSources[0];
        _nightSound = audioSources[1];
    }

    void LateUpdate()
    {
        _dayTime += Time.deltaTime;
        _dayTime %= _fullDayTime;
        _dayPhase = _dayTime / _fullDayTime;

        //_sun.transform.Rotate(_deltaAngle * Time.deltaTime, 0, 0);
        //_moon.transform.Rotate(_deltaAngle * Time.deltaTime, 0, 0);

        _lightElem.transform.Rotate(_deltaAngle * Time.deltaTime, 0, 0);

        float koef = Mathf.Abs(Mathf.Cos(_dayPhase * 2f * Mathf.PI));
        // коеф. плавного перехода текстур и освещения

        if (_dayPhase > 0.25f && _dayPhase < 0.75f) // ночная фаза
        {
            if (!_nightSound.isPlaying)
            {
                _nightSound.Play();
                _daySound.Stop();
            }
            
            if (RenderSettings.skybox != nightSkybox)
            {
                RenderSettings.skybox = nightSkybox;
            }

            RenderSettings.ambientIntensity = koef / 2f; // свет неба (дополнительный)

            _sunObj.SetActive(false);
            _moonObj.SetActive(true);
        }
        else // дневная фаза
        {
            if(!_daySound.isPlaying)
            {
                _daySound.Play();
                _nightSound.Stop();
            }

            if(RenderSettings.skybox != daySkybox)
            {
                RenderSettings.skybox = daySkybox;
            }

            RenderSettings.ambientIntensity = koef;

            _sunObj.SetActive(true);
            _moonObj.SetActive(false);
        }

        RenderSettings.skybox.SetFloat("_Exposure", 0.2f + koef * 0.8f); // яркость (видимость) самой текстуры

        _daySound.mute = _nightSound.mute = GameSettings.IsMuted;
        _daySound.volume = _nightSound.volume = GameSettings.BackgroundVolume;
    }
}