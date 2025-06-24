using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGuessImageConfig", menuName = "Guess Configs/Guess By Image Config")]
public class ConfigGuessByImage : ScriptableObject
{
    [SerializeField] private List<Sprite> _icons;
    [SerializeField] private List<string> _names;

    public IReadOnlyList<Sprite> Icons => _icons.AsReadOnly();
    public IReadOnlyList<string> Names => _names.AsReadOnly();
}
