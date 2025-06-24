using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamesConfigSwitcher : MonoBehaviour
{
    #region Fields
    [Header("Clips and Icons")]
    [SerializeField] private ConfigGuessByName _config;
    [SerializeField] private int _maxConfigLength;

    [Header("UI")]
    [SerializeField] private Text _name;
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
        _trueIcon.sprite = _icons[idConfig];
        _name.text = _names[idConfig];
        SetRandomFalseIcons();
    }

    #region Private Methods
    private void LoadConfig()
    {
        _names = new List<string>(_config.Names);
        _icons = new List<Sprite>(_config.Icons);
    }
    private void GenerateConfig()
    {
        for (int i = _names.Count; i > _maxConfigLength; i--)
        {
            int id = Random.Range(0, _names.Count);
            _names.RemoveAt(id);
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
