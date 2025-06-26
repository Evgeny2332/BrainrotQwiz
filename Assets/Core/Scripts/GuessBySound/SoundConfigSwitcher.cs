using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundConfigSwitcher : MonoBehaviour
{
    #region Fields
    [Header("Clips and Icons")]
    [SerializeField] private ConfigGuessBySound _config;
    [SerializeField] private int _maxConfigCount;

    [Header("ButtonImages")]
    [SerializeField] private Image _trueIcon;
    [SerializeField] private Image[] _falseIcons;

    private List<AudioClip> _clips;
    private List<Sprite> _icons;
    #endregion

    #region MonoBehaviour
    private void Awake()
    {
        LoadConfig();
        GenerateConfig();
    }
    #endregion

    public void SwitchConfig(int idConfig, SoundBlock soundBlock)
    {
        _trueIcon.sprite = _icons[idConfig];
        soundBlock.ChangeAudioClip(_clips[idConfig]);
        SetRandomFalseIcons();
    }

    #region Private Methods
    private void LoadConfig()
    {
        _clips = new List<AudioClip>(_config.Clips);
        _icons = new List<Sprite>(_config.Icons);
    }
    private void GenerateConfig()
    {
        for (int i = _clips.Count; i > _maxConfigCount; i--)
        {
            int id = Random.Range(0, _clips.Count);
            _clips.RemoveAt(id);
            _icons.RemoveAt(id);
        }
    }

    private void SetRandomFalseIcons()
    {
        HashSet<string> usedNames = new HashSet<string>();
        string correctName = _trueIcon.sprite.name;
        usedNames.Add(correctName);

        int count = 0;

        while (count < _falseIcons.Length)
        {
            Sprite candidate = _config.Icons[Random.Range(0, _config.Icons.Count)];

            if (!usedNames.Contains(candidate.name))
            {
                _falseIcons[count].sprite = candidate;
                usedNames.Add(candidate.name);
                count++;
            }
        }
    }
    #endregion
}
