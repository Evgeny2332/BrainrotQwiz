using System;
using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class SoundBlock : MonoBehaviour
{
    #region Fields
    private AudioSource _soundPlayer;

    [Header("Settings")]
    [SerializeField] private int _soundDuration;

    private CancellationTokenSource _token;
    private bool _isPlaying;

    public event Action OnSoundStarted;
    public event Action OnSoundStopped;
    #endregion

    #region MonoBehaviour
    private void Awake() => _soundPlayer = GetComponent<AudioSource>();
    #endregion

    public void PlaySound()
    {
        if (_isPlaying) return;

        _isPlaying = true;
        _token = new CancellationTokenSource();
        PlaySoundDuration().Forget();
    }
    public void StopSound()
    {
        _soundPlayer.Stop();

        if (_token != null)
        {
            _token.Cancel();
            _token.Dispose();
            _token = null;
        }
        _isPlaying = false;

        OnSoundStopped?.Invoke();
    }
    public void ChangeAudioClip(AudioClip clip) => _soundPlayer.clip = clip;

    #region Private Methods
    private async UniTask PlaySoundDuration()
    {
        _soundPlayer.Play();
        OnSoundStarted?.Invoke();
        await UniTask.Delay(_soundDuration * 1000, cancellationToken: _token.Token);
        StopSound();
    }
    #endregion
}
