using System;
using UnityEngine;

public class GuessBySoundController : MonoBehaviour
{
    #region Field
    [SerializeField] private Timer _timer;
    [SerializeField] private AnswerChecker _answerChecker;
    [SerializeField] private SoundBlock _soundBlock;

    public event Action OnGiveAnswer;
    #endregion

    #region MonoBehaviour
    private void OnEnable()
    {
        _timer.OnTimeUp += TimeUp;
        _answerChecker.OnButtonPressed += GiveAnswer;
    }
    private void OnDisable()
    {
        _timer.OnTimeUp -= TimeUp;
        _answerChecker.OnButtonPressed -= GiveAnswer;
    }

    private void Start()
    {
        _soundBlock.PlaySound();

        _timer.Init(30);
    }
    #endregion

    private void TimeUp()
    {
        Debug.Log("Время вышло!");
    }

    private void GiveAnswer(bool isRight)
    {

        OnGiveAnswer?.Invoke();
    }

    private void EndGame()
    {
        Debug.Log("Карточки закончились");
    }
}
