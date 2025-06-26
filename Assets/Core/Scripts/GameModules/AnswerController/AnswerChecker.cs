using System;
using UnityEngine;

public class AnswerChecker : MonoBehaviour
{
    public event Action<bool> OnButtonPressed;

    public void SubmitAnswer(bool isRight) => OnButtonPressed.Invoke(isRight);
}
