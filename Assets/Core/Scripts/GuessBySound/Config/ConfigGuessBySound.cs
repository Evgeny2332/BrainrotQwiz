using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGuessSoundConfig", menuName = "Guess Configs/Guess By Sound Config")]
public class ConfigGuessBySound : ScriptableObject
{
    [SerializeField] private List<AudioClip> _clips;
    [SerializeField] private List<Sprite> _icons;

    public List<AudioClip> Clips => _clips;
    public List<Sprite> Icon => _icons;
}
