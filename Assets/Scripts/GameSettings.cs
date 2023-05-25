using UnityEngine;
using System.IO;
using System;

public class GameSettings : MonoBehaviour
{
    private const string _settingsFileName = "settings.txt";

    private static bool _isMuted;
    public static bool IsMuted
    { 
        get => _isMuted;
        set { _isMuted = value; SaveSettings(); }
    }
    private static float _backgroundVolume;
    public static float BackgroundVolume
    {
        get => _backgroundVolume;
        set { _backgroundVolume = value; SaveSettings(); }
    }

    public static void SaveSettings()
    {
        string path = Application.persistentDataPath + "/" + _settingsFileName;
        string data = $"{_isMuted}\n{_backgroundVolume}";
        File.WriteAllText(path, data);
    }
    public static void LoadSettings()
    {
        string path = Application.persistentDataPath + "/" + _settingsFileName;
        Debug.Log(path);
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            _isMuted = (lines.Length > 0) ? Convert.ToBoolean(lines[0]) : false;
            _backgroundVolume = (lines.Length > 1) ? Convert.ToSingle(lines[1]) : 0;
        }
    }
}
