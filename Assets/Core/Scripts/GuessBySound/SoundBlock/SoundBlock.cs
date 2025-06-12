using System;
using System.Collections;
using UnityEngine;

public class SoundBlock : MonoBehaviour
{
    #region Fields
    private AudioSource _soundPlayer;

    [Header("Settings")]
    [SerializeField] private float _soundDuration;

    public event Action OnSoundStarted;
    public event Action OnSoundStopped;
    #endregion

    #region MonoBehaviour
    private void Awake() => _soundPlayer = GetComponent<AudioSource>();
    #endregion

    public void PlaySound() => StartCoroutine(PlaySoundDuration());
    public void StopSound()
    {
        _soundPlayer.Stop();
        OnSoundStopped?.Invoke();
    }
    public void ChangeAudioClip(AudioClip clip) => _soundPlayer.clip = clip;

    #region Private Methods
    private IEnumerator PlaySoundDuration()
    {
        _soundPlayer.Play();
        OnSoundStarted?.Invoke();
        yield return new WaitForSeconds(_soundDuration);
        StopSound();
    }
    #endregion
}
