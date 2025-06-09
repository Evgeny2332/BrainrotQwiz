using System;
using UnityEngine;

public class AnswerChecker : MonoBehaviour
{
    #region Fields
    public event Action OnButtonPressed;
    #endregion

    public void AnswerCorrectly()
    {
        Debug.Log("Верно");
        OnButtonPressed?.Invoke();
    }
    public void AnswerIncorrectly()
    {
        Debug.Log("Неверно");
        OnButtonPressed?.Invoke();
    }
}
