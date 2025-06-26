using UnityEngine;

public class GuessBySoundController : MonoBehaviour
{
    #region Fields
    [SerializeField] private SoundBlock _soundBlock;
    [SerializeField] private Timer _timer;

    [SerializeField] private AnswerController _answerController;
    [SerializeField] private AnswerCounter _answerCounter;

    [SerializeField] private SoundConfigSwitcher _configSwitcher;
    [SerializeField] private ButtonShuffler _buttonShuffler;

    [SerializeField] private ResultGame _resultGame;
    #endregion

    #region MonoBehaviour
    private void OnEnable()
    {
        _timer.OnTimeUp += ShowResult;

        _answerController.OnAnswerSubmitted += SubmitAnswer;
        _answerController.OnAnswerCompleted += NextConfig;
    }
    private void OnDisable()
    {
        _timer.OnTimeUp -= ShowResult;

        _answerController.OnAnswerSubmitted -= SubmitAnswer;
        _answerController.OnAnswerCompleted -= NextConfig;
    }

    private void Start()
    {
        _configSwitcher.SwitchConfig(_answerCounter.GetCurrentConfigIndex(), _soundBlock);

        _timer.StartTimer();
        _soundBlock.PlaySound();
    }
    #endregion

    #region Private Methods
    private void ShowResult()
    {
        _resultGame.ShowResults(_answerCounter.RightAnswerCount, _timer.GetTimeSpent(), _answerCounter.MaxStrikeRightAnswers);
        _soundBlock.StopSound();
    }

    private void SubmitAnswer(bool isRight)
    {
        _answerCounter.SetAnswer(isRight);

        _soundBlock.StopSound();
    }

    private void NextConfig()
    {
        if (!_answerCounter.IsAllTasksCompleted)
        {
            _answerCounter.UpdateAnswerCounter();

            _configSwitcher.SwitchConfig(_answerCounter.GetCurrentConfigIndex(), _soundBlock);
            _buttonShuffler.Shuffle();

            _soundBlock.PlaySound();
        }
        else
            ShowResult();
    }
    #endregion
}
