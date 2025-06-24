using UnityEngine;
using UnityEngine.UI;

public class GuessByNameController : MonoBehaviour
{
    #region Fields
    [SerializeField] private Timer _timer;
    [SerializeField] private NamesConfigSwitcher _switcher;
    [SerializeField] private ButtonShuffler _shuffler;

    [SerializeField] private AnswerChecker _checker;
    [SerializeField] private AnswerCounter _counter;

    [SerializeField] private ResultGame _resultGame;
    #endregion

    #region MonoBehaviour
    private void OnEnable()
    {
        _timer.OnTimeUp += ShowResults;

        _checker.OnButtonPressed += GetAnswer;
        _checker.OnHideAnswerIcon += NextConfig;
    }
    private void OnDisable()
    {
        _timer.OnTimeUp -= ShowResults;

        _checker.OnButtonPressed -= GetAnswer;
        _checker.OnHideAnswerIcon -= NextConfig;
    }

    private void Start()
    {
        _timer.StartTimer();
        _switcher.SwitchConfig(_counter.AnswerCount);
    }
    #endregion

    #region Private Methods

    private void GetAnswer(bool isRight) => _counter.SetAnswer(isRight);

    private void NextConfig()
    {
        if (_counter.IsAllTasksCompleted)
        {
            ShowResults();
            return;
        }

        ProceedToNext();
    }

    private void ProceedToNext()
    {
        _shuffler.Shuffle();
        _counter.UpdateAnswerCounter();
    }

    private void ShowResults()
    {
        _timer.StopTimer();

        _resultGame.ShowResults(_counter.RightAnswerCount, _timer.GetTimeSpent(), _counter.MaxStrikeRightAnswers);
    }
    #endregion
}
