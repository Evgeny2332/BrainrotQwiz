using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    #region Fields
    [SerializeField] private Timer _timer;

    [SerializeField] private Text _timerText;
    #endregion

    #region MonoBehaviour
    private void OnEnable() => _timer.OnTimeChanged += UpdateTimeDisplay;
    private void OnDisable() => _timer.OnTimeChanged -= UpdateTimeDisplay;
    #endregion

    #region Private Methods
    private void UpdateTimeDisplay(int minutes, int seconds)
    {
        _timerText.text = $"{minutes:D2}:{seconds:D2}";
    }
    #endregion
}
