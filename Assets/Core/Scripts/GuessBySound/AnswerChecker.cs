using System;
using UnityEngine;

public class AnswerChecker : MonoBehaviour
{
    #region Fields
    public event Action OnButtonPressed;
    #endregion

    public void AnswerCorrectly()
    {
        Debug.Log("�����");
        OnButtonPressed?.Invoke();
    }
    public void AnswerIncorrectly()
    {
        Debug.Log("�������");
        OnButtonPressed?.Invoke();
    }
}
