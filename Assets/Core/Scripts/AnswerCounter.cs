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

    private void Start() => UpdateAnswerCounter();

    public void SetAnswer(bool isRight)
    {
        if (isRight)
        {
            _rightAnswerCount++;

            _strikeRightAnswers += 1;
            if (_maxStrikeRightAnswers < _strikeRightAnswers)
                _maxStrikeRightAnswers = _strikeRightAnswers;
        }
        else
        {
            _strikeRightAnswers = 0;
        }

        _answerCount++;
    }

    public int GetAnswerCount() => _answerCount - 1;
    public int GetRightAnswerCount() => _rightAnswerCount;
    public int GetStrikeRightAnswers() => _maxStrikeRightAnswers;
    public bool IsEndTasks() => _answerCount > _maxAnswerCount;
    public void UpdateAnswerCounter() => _answerCounterText.text = $"{_answerCount}/{_maxAnswerCount}";
}
