using System;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCounter : MonoBehaviour
{
    #region Fields
    [SerializeField] private Text _answerCounterText;

    [SerializeField] private int _answerCount;
    [SerializeField] private int _maxAnswerCount;

    [SerializeField] private int _rightAnswerCount;

    public event Action OnTaskOver;
    #endregion

    private void Start()
    {
        UpdateAnswerCounter();
    }

    public void SetAnswer(bool isRight)
    {
        if (isRight) _rightAnswerCount++;

        if(_answerCount < _maxAnswerCount)
            _answerCount++;
        else
            OnTaskOver?.Invoke();

        UpdateAnswerCounter();
    }

    public int GetAnswerCount() => _answerCount - 1;
    public int GetRightAnswerCount() => _rightAnswerCount;

    private void UpdateAnswerCounter() => _answerCounterText.text = $"{_answerCount}/{_maxAnswerCount}";
}
