using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameConfigSwitcher : MonoBehaviour
{
    #region Fields

    [Header("Config")]
    [SerializeField] private ConfigGuessByName _config;
    [SerializeField] private int _maxConfigLength = 15;

    [Header("UI")]
    [SerializeField] private Text _nameText;
    [SerializeField] private Image _trueIcon;
    [SerializeField] private Image[] _falseIcons;

    private List<string> _names;
    private List<Sprite> _icons;

    #endregion

    #region MonoBehaviour
    private void Awake()
    {
        LoadConfig();
        GenerateConfig();
    }
    #endregion

    public void SwitchConfig(int idConfig)
    {
        if (idConfig >= _names.Count || idConfig >= _icons.Count) return;

        _nameText.text = _names[idConfig];

        _trueIcon.sprite = _icons[idConfig];
        SetRandomFalseIcons(_icons[idConfig]);
    }

    #region Private Methods

    private void LoadConfig()
    {
        _names = new List<string>(_config.Names);
        _icons = new List<Sprite>(_config.Icons);
    }

    private void GenerateConfig()
    {
        while (_names.Count > _maxConfigLength)
        {
            int index = Random.Range(0, _names.Count);
            _names.RemoveAt(index);
            _icons.RemoveAt(index);
        }
    }

    private void SetRandomFalseIcons(Sprite correctSprite)
    {
        HashSet<string> used = new HashSet<string> { correctSprite.name };
        int count = 0;

        while (count < _falseIcons.Length)
        {
            Sprite candidate = _icons[Random.Range(0, _icons.Count)];

            if (!used.Contains(candidate.name))
            {
                _falseIcons[count].sprite = candidate;
                used.Add(candidate.name);
                count++;
            }
        }
    }

    #endregion
}
