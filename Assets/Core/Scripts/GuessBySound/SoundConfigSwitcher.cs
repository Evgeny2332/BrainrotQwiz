using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundConfigSwitcher : MonoBehaviour
{
    [Header("Clips and Icons")]
    [SerializeField] private ConfigGuessBySound _config;
    [SerializeField] private int _maxConfigLength;

    [Header("ButtonImages")]
    [SerializeField] private Image _trueIcon;
    [SerializeField] private Image[] _falseIcons;

    private List<AudioClip> _clips;
    private List<Sprite> _icons;

    private void Awake()
    {
        LoadConfig();
        GenerateConfig();
    }

    private void LoadConfig()
    {
        _clips = new List<AudioClip>(_config.Clips);
        _icons = new List<Sprite>(_config.Icon);
    }

    private void GenerateConfig()
    {
        for (int i = _clips.Count; i > _maxConfigLength; i--)
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
            Sprite candidate = _config.Icon[Random.Range(0, _config.Icon.Count)];

            if (!usedNames.Contains(candidate.name))
            {
                _falseIcons[count].sprite = candidate;
                usedNames.Add(candidate.name);
                count++;
            }
        }
    }


    public void SwitchConfig(int idConfig, SoundBlock soundBlock)
    {
        _trueIcon.sprite = _icons[idConfig];
        soundBlock.ChangeAudioClip(_clips[idConfig]);
        SetRandomFalseIcons();
    }
}
