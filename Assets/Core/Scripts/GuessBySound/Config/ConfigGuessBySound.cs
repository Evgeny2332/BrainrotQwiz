using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGuessSoundConfig", menuName = "Guess Configs/Guess By Sound Config")]
public class ConfigGuessBySound : ScriptableObject
{
    [SerializeField] private List<AudioClip> _clips;
    [SerializeField] private List<Sprite> _icons;

    public IReadOnlyList<AudioClip> Clips => _clips.AsReadOnly();
    public IReadOnlyList<Sprite> Icons => _icons.AsReadOnly();
}
