using System;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Threading;

public class Timer : MonoBehaviour
{
    #region Fields
    [SerializeField] private Text _timerText;

    [SerializeField] private int _minutes;
    [SerializeField] private int _seconds;

    private CancellationTokenSource _token;
    private bool _isRunning;

    public event Action OnTimeUp;
    #endregion

    #region MonoBehaviour
    private void Awake()
    {
        UpdateTimeDisplay();
    }
    #endregion

    public void StartTimer()
    {
        if(_isRunning) return;

        _isRunning = true;
        _token = new CancellationTokenSource();
        RunTimerAsync().Forget();
    }
    public void StopTimer()
    {
        _token.Cancel();
        _token.Dispose();
        _token = null;

        _isRunning = false;
    }

    #region Private Methods
    private async UniTask RunTimerAsync()
    {
        while (_seconds > 0 || _minutes > 0)
        {
            await UniTask.Delay(1000, cancellationToken: _token.Token);
            CalculateTime();
            UpdateTimeDisplay();
        }

        OnTimeUp?.Invoke();
    }

    private void UpdateTimeDisplay()
    {
        _timerText.text = $"{_minutes:D2}:{_seconds:D2}";
    }
    private void CalculateTime()
    {
        if (_seconds == 0)
        {
            if (_minutes > 0)
            {
                _minutes--;
                _seconds = 59;
            }
        }
        else
            _seconds--;
    }

    #endregion
}
