using System;
using System.Collections;
using UnityEngine;

public class SoundBlock : MonoBehaviour
{
    #region Fields
    private AudioSource _soundPlayer;

    [Header("Windows")]
    [SerializeField] private GameObject _sound;
    [SerializeField] private GameObject _replay;

    [Header("Settings")]
    [SerializeField] private float _soundDuration;

    public event Action OnSoundComplete;
    #endregion

    #region MonoBehabiour
    private void Awake()
    {
        _soundPlayer = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlaySound();
    }
    #endregion

    public void SetAudioClip(AudioClip clip) => _soundPlayer.clip = clip;
    public void PlaySound()
    {
        StartCoroutine(PlaySoundDuration());
    }

    private IEnumerator PlaySoundDuration()
    {
        _soundPlayer.Play();
        yield return new WaitForSeconds(_soundDuration);
        _soundPlayer.Stop();

        OnSoundComplete?.Invoke();
    }
}
