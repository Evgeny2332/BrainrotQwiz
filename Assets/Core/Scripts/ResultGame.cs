using UnityEngine;
using UnityEngine.UI;

public class ResultGame : MonoBehaviour
{
    [SerializeField] private Text _maxRightAnswers;
    [SerializeField] private Text _timeSpent;
    [SerializeField] private Text _strikeRigthAnswers;

    [SerializeField] private GameObject _resultWindow;

    public void Enable(int maxRightAnswers, string timeSpent, int strikeRightAnswers)
    {
        _resultWindow.SetActive(true);
        UpdateDates(maxRightAnswers, timeSpent, strikeRightAnswers);
    }
    public void Disable()
    {
        _resultWindow.SetActive(false);
    }

    private void UpdateDates(int maxRightAnswers, string timeSpent, int strikeRightAnswers)
    {
        _maxRightAnswers.text = $"{maxRightAnswers}/15";
        _timeSpent.text = "Время: " + timeSpent;
        _strikeRigthAnswers.text = $"Страйк: {strikeRightAnswers}";
    }
}
