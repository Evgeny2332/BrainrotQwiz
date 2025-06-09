using System;
using System.Collections;
using UnityEngine;

public class SoundBlock : MonoBehaviour
{
    #region Fields
    private AudioSource _soundPlayer;

    [Header("References")]
    [SerializeField] private AnswerChecker _checker;

    [Header("Windows")]
    [SerializeField] private GameObject _sound;
    [SerializeField] private GameObject _replay;

    [Header("Settings")]
    [SerializeField] private float _soundDuration;

    #endregion

    #region MonoBehabiour
    private void OnEnable()
    {
        _checker.OnButtonPressed += StopSound;
    }
    private void OnDisable()
    {
        _checker.OnButtonPressed -= StopSound;
    }
    #endregion

    public void Init()
    {
        _soundPlayer = GetComponent<AudioSource>();
    }
    public void SetAudioClip(AudioClip clip) => _soundPlayer.clip = clip;
    public void PlaySound()
    {
        StartCoroutine(PlaySoundDuration());
    }

    #region Private Methods
    private void StopSound()
    {
        StopCoroutine(PlaySoundDuration());
        _soundPlayer.Stop();
    }
    private IEnumerator PlaySoundDuration()
    {
        _soundPlayer.Play();
        ActivateWindow(_sound);
        yield return new WaitForSeconds(_soundDuration);
        _soundPlayer.Stop();
        ActivateWindow(_replay);
    }
    private void ActivateWindow(GameObject activeWindow)
    {
        _sound.SetActive(false);
        _replay.SetActive(false);
        activeWindow.SetActive(true);
    }
    #endregion
}
