using UnityEngine;
using UnityEngine.UI;

public class ResultGame : MonoBehaviour
{
    [SerializeField] private Text _maxRightAnswers;
    [SerializeField] private Text _timeSpent;
    [SerializeField] private Text _strikeRightAnswers;

    [SerializeField] private GameObject _resultWindow;

    private const int MaxPossibleAnswers = 15;

    public void ShowResults(int maxRightAnswers, string timeSpent, int strikeRightAnswers)
    {
        _resultWindow.SetActive(true);
        UpdateView(maxRightAnswers, timeSpent, strikeRightAnswers);
    }
    public void Disable()
    {
        _resultWindow.SetActive(false);
    }

    private void UpdateView(int maxRightAnswers, string timeSpent, int strikeRightAnswers)
    {
        _maxRightAnswers.text = $"{maxRightAnswers}/{MaxPossibleAnswers}";
        _timeSpent.text = "Время: " + timeSpent;
        _strikeRightAnswers.text = $"Страйк: {strikeRightAnswers}";
    }
}
