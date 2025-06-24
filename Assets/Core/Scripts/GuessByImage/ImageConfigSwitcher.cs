using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageConfigSwitcher : MonoBehaviour
{
    #region Fields
    [Header("Clips and Icons")]
    [SerializeField] private ConfigGuessByImage _config;
    [SerializeField] private int _maxConfigLength;

    [Header("UI Elements")]
    [SerializeField] private Image _trueIcon;
    [SerializeField] private Text _trueName;
    [SerializeField] private Text[] _falseNames;

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
        _trueName.text = _names[idConfig];
        SetRandomFalseNames(_names[idConfig]);
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
            int id = Random.Range(0, _names.Count);
            _names.RemoveAt(id);
            _icons.RemoveAt(id);
        }
    }

    private void SetRandomFalseNames(string correctName)
    {
        HashSet<string> used = new HashSet<string> { correctName };
        int count = 0;

        while (count < _falseNames.Length)
        {
            int index = Random.Range(0, _names.Count);
            string candidate = _names[index];

            if (!used.Contains(candidate))
            {
                _falseNames[count].text = candidate;
                used.Add(candidate);
                count++;
            }
        }
    }
    #endregion
}
