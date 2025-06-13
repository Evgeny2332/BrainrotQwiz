using System;
using UnityEngine;

public class GuessBySoundController : MonoBehaviour
{
    #region Fields
    [SerializeField] private SoundBlock _soundBlock;
    [SerializeField] private Timer _timer;
    [SerializeField] private AnswerChecker _checker;
    [SerializeField] private AnswerCounter _counter;
    [SerializeField] private ButtonShuffler _shuffler;
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
    }
    #endregion

    private void TimeUp()
    {
        Debug.Log("Время вышло");
    }

    private void GetAnswer(bool isRight)
    {
        _counter.SetAnswer(isRight);
        _shuffler.Shuffle();
    }

    private void FinishGame()
    {
        Debug.Log("Вопросы закончились");
    }
}
