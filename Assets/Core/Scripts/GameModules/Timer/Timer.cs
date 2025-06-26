using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class Timer : MonoBehaviour
{
    #region Fields
    [SerializeField] private int _minutes;
    [SerializeField] private int _seconds;

    private int _initialMinutes;
    private int _initialSeconds;

    private CancellationTokenSource _token;
    private bool _isRunning = false;

    public event Action OnTimeUp;
    public event Action<int, int> OnTimeChanged;
    #endregion

    #region MonoBehaviour
    private void Start() => InitTime();
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
        if(!_isRunning) return;

        if(_token != null)
            ClearToken();

        _isRunning = false;
    }

    public string GetTimeSpent()
    {
        int totalStartSeconds = _initialMinutes * 60 + _initialSeconds;
        int totalCurrentSeconds = _minutes * 60 + _seconds;
        int timeSpent = totalStartSeconds - totalCurrentSeconds;

        int minutes = timeSpent / 60;
        int seconds = timeSpent % 60;

        return $"{minutes:D2}:{seconds:D2}";
    }


    #region Private Methods
    private void InitTime()
    {
        _initialMinutes = _minutes;
        _initialSeconds = _seconds;

        OnTimeChanged?.Invoke(_minutes, _seconds);
    }

    private async UniTask RunTimerAsync()
    {
        while (_seconds > 0 || _minutes > 0)
        {
            await UniTask.Delay(1000, cancellationToken: _token.Token);
            CalculateTime();
            OnTimeChanged?.Invoke(_minutes, _seconds);
        }

        OnTimeUp?.Invoke();
    }

    private void CalculateTime()
    {
        if (_seconds > 0)
            _seconds--;
        else if (_minutes > 0)
        {
            _minutes--;
            _seconds = 59;
        }
    }

    private void ClearToken()
    {
        _token.Cancel();
        _token.Dispose();
        _token = null;
    }
    #endregion
}
