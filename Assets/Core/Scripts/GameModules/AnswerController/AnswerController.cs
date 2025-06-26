using System;
using UnityEngine;

public class AnswerController : MonoBehaviour
{
    #region Fields
    [SerializeField] private AnswerChecker _checker;
    [SerializeField] private AnswerIconHandler _iconHandler;

    public event Action<bool> OnAnswerSubmitted;
    public event Action OnAnswerCompleted;
    #endregion

    #region MonoBehaviour
    private void OnEnable()
    {
        _checker.OnButtonPressed += HandleAnswer;
        _iconHandler.OnHideAnswerIcon += CompleteAnswer;
    }
    private void OnDisable()
    {
        _checker.OnButtonPressed -= HandleAnswer;
        _iconHandler.OnHideAnswerIcon -= CompleteAnswer;
    }
    #endregion

    #region Private Methods
    private void HandleAnswer(bool isRight) => OnAnswerSubmitted?.Invoke(isRight);
    private void CompleteAnswer() => OnAnswerCompleted?.Invoke();
    #endregion
}
