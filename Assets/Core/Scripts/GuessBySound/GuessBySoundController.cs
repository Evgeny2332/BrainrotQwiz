using UnityEngine;

public class GuessBySoundController : MonoBehaviour
{
    #region Field
    [SerializeField] private Timer _timer;
    [SerializeField] private AnswerChecker _answerChecker;
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
        _timer.Init(5);
    }
    #endregion

    private void TimeUp()
    {
        Debug.Log("����� �����!");
    }

    private void GiveAnswer(bool isRight)
    {
        if (isRight)
        {
            Debug.Log("����� ������");
        }
        else
        {
            Debug.Log("����� ��������");
        }
    }
}
