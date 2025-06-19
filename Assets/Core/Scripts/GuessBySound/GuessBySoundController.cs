using UnityEngine;

public class GuessBySoundController : MonoBehaviour
{
    #region Fields
    [SerializeField] private SoundBlock _soundBlock;
    [SerializeField] private Timer _timer;
    [SerializeField] private SoundConfigSwitcher _switcher;
    [SerializeField] private ButtonShuffler _shuffler;

    [SerializeField] private AnswerChecker _checker;
    [SerializeField] private AnswerCounter _counter;

    [SerializeField] private ResultGame _resultGame;
    #endregion

    #region MonoBehaviour
    private void OnEnable()
    {
        _timer.OnTimeUp += ResultGame;

        _checker.OnButtonPressed += GetAnswer;
        _checker.OnHideAnswerIcon += NextConfig;
    }
    private void OnDisable()
    {
        _timer.OnTimeUp -= ResultGame;

        _checker.OnButtonPressed -= GetAnswer;
        _checker.OnHideAnswerIcon -= NextConfig;
    }

    private void Start()
    {
        _timer.StartTimer();
        _switcher.SwitchConfig(_counter.GetAnswerCount(), _soundBlock);

        _soundBlock.PlaySound();
    }
    #endregion

    #region Private Methods
    private void GetAnswer(bool isRight)
    {
        _counter.SetAnswer(isRight);
        _soundBlock.StopSound();
    }
    private void NextConfig()
    {
        if (_counter.IsEndTasks())
        {
            ResultGame();
            return;
        }

        _shuffler.Shuffle();
        _switcher.SwitchConfig(_counter.GetAnswerCount(), _soundBlock);
        _soundBlock.PlaySound();
        _counter.UpdateAnswerCounter();
    }

    private void ResultGame()
    {
        _timer.StopTimer();
        _soundBlock.StopSound();

        _resultGame.Enable(_counter.GetRightAnswerCount(), _timer.GetTimeSpent(), _counter.GetStrikeRightAnswers());
    }
    #endregion
}
