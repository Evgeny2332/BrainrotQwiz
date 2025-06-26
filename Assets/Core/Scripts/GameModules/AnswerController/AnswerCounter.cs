using UnityEngine;
using UnityEngine.UI;

public class AnswerCounter : MonoBehaviour
{
    #region Fields
    [SerializeField] private Text _answerCounterText;

    [SerializeField] private int _answerCount;
    [SerializeField] private int _maxAnswerCount;

    [SerializeField] private int _rightAnswerCount;

    private int _maxStrikeRightAnswers;
    private int _strikeRightAnswers;
    #endregion

    #region Properties
    public int AnswerCount => _answerCount;
    public int RightAnswerCount => _rightAnswerCount;
    public int MaxStrikeRightAnswers => _maxStrikeRightAnswers;
    public bool IsAllTasksCompleted => _answerCount > _maxAnswerCount;
    #endregion

    #region MonoBehaviour
    private void Start() => UpdateAnswerCounter();
    #endregion

    public void SetAnswer(bool isRight)
    {
        if (isRight)
        {
            _rightAnswerCount++;

            _strikeRightAnswers++;
            _maxStrikeRightAnswers = Mathf.Max(_maxStrikeRightAnswers, _strikeRightAnswers);
        }
        else
            _strikeRightAnswers = 0;

        _answerCount++;
    }

    public void UpdateAnswerCounter() => _answerCounterText.text = $"{_answerCount}/{_maxAnswerCount}";
    public int GetCurrentConfigIndex() => _answerCount - 1;
}
