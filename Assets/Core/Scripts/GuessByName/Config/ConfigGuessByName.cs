using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGuessNamesConfig", menuName = "Guess Configs/Guess By Name Config")]
public class ConfigGuessByName : ScriptableObject
{
    [SerializeField] private List<string> _names;
    [SerializeField] private List<Sprite> _icons;

    public IReadOnlyList<string> Names => _names.AsReadOnly();
    public IReadOnlyList<Sprite> Icons => _icons.AsReadOnly();
}
