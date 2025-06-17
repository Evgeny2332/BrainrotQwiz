using System;
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
        _timer.OnTimeUp += TimeUp;
        _checker.OnButtonPressed += GetAnswer;
        _counter.OnTaskOver += FinishGame;
    }
    private void OnDisable()
    {
        _timer.OnTimeUp -= TimeUp;
        _checker.OnButtonPressed -= GetAnswer;
        _counter.OnTaskOver -= FinishGame;
    }

    private void Start()
    {
        _timer.StartTimer();
        _switcher.SwitchConfig(_counter.GetAnswerCount(), _soundBlock);
        _soundBlock.PlaySound();
    }
    #endregion

    private void TimeUp()
    {
        ResultGame();
    }

    private void GetAnswer(bool isRight)
    {
        _counter.SetAnswer(isRight);
        _soundBlock.StopSound();
        _shuffler.Shuffle();
    }
    private void NextConfig()
    {
        _switcher.SwitchConfig(_counter.GetAnswerCount(), _soundBlock);
        _soundBlock.PlaySound();
    }

    private void FinishGame()
    {
        ResultGame();
    }

    private void ResultGame()
    {
        _resultGame.Enable();

        _timer.StopTimer();
        _soundBlock.StopSound();
    }
}
