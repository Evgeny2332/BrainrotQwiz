using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Guess Sound Config", menuName = "Configs/GuessSound")]
public class GuessOfSoundConfig : ScriptableObject
{
    [SerializeField] private List<AudioClip> _sounds;
    [SerializeField] private List<Sprite> _icons;
}
