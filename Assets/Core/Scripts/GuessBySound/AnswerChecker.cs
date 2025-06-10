using System;
using UnityEngine;

public class AnswerChecker : MonoBehaviour
{
    #region Fields
    public event Action<bool> OnButtonPressed;
    #endregion

    public void GiveAnswer(bool isRight) => OnButtonPressed?.Invoke(isRight);
}
