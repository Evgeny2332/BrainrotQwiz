using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class AnswerChecker : MonoBehaviour
{
    #region Fields
    [SerializeField] private int _delayHideAnswerIcon = 1;
    [SerializeField] private GameObject _barrier;

    public event Action<bool> OnButtonPressed;
    public event Action OnHideAnswerIcon;
    #endregion

    public void SubmitAnswer(bool isRight) => OnButtonPressed.Invoke(isRight);
    public void ActivateAnswerIcon(GameObject icon)
    {
        if(icon == null) return;

        icon.SetActive(true);
        _barrier?.SetActive(true);
        HideAnswerIcon(icon).Forget();
    }

    private async UniTask HideAnswerIcon(GameObject icon)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_delayHideAnswerIcon));
        icon.SetActive(false);
        _barrier?.SetActive(false);
        OnHideAnswerIcon?.Invoke();
    }
}
