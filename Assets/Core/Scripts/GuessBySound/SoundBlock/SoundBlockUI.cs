using UnityEngine;

public class SoundBlockUI : MonoBehaviour
{
    #region Fields
    [SerializeField] private SoundBlock _soundBlock;

    [SerializeField] private GameObject _soundWindow;
    [SerializeField] private GameObject _replayWindow;

    private GameObject _lastOpenWindow;
    #endregion

    #region MonoBehaviour
    private void OnEnable()
    {
        _soundBlock.OnSoundStarted += PlaySound;
        _soundBlock.OnSoundStopped += StopSound;
    }
    private void OnDisable()
    {
        _soundBlock.OnSoundStarted -= PlaySound;
        _soundBlock.OnSoundStopped -= StopSound;
    }
    #endregion

    private void PlaySound() => OpenWindow(_soundWindow);
    private void StopSound() => OpenWindow(_replayWindow);

    private void OpenWindow(GameObject window)
    {
        if (_lastOpenWindow == window) return;

        window.SetActive(true);
        _lastOpenWindow?.SetActive(false);
        _lastOpenWindow = window;
    }
}
