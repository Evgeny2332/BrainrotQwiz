using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    #region Fields
    [SerializeField] private Text _timerText;

    [SerializeField] private int _minutes;
    [SerializeField] private int _seconds;

    public event Action OnTimeUp;
    #endregion

    #region MonoBehaviour

    #endregion

    public void Init(int seconds, int minutes = 0)
    {
        _seconds = seconds;
        _minutes = minutes;

        UpdateTimeDisplay();
        StartCoroutine(StartTimer());
    }

    #region Private Methods
    private IEnumerator StartTimer()
    {
        while (_seconds > 0 || _minutes > 0)
        {
            yield return new WaitForSeconds(1);
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
        _seconds--;

        if (_seconds < 0 && _minutes >= 0)
        {
            _minutes--;
            _seconds = 59;
        }           
    }
    #endregion
}
