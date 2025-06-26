using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class AnswerIconHandler : MonoBehaviour
{
    #region Fields
    [SerializeField] private int _delayHideAnswerIcon = 1;
    [SerializeField] private GameObject _barrier;

    public event Action OnHideAnswerIcon;
    #endregion

    public void ActivateAnswerIcon(GameObject icon)
    {
        if (icon == null) return;

        icon.SetActive(true);
        _barrier?.SetActive(true);
        HideAnswerIconAsync(icon).Forget();
    }

    private async UniTask HideAnswerIconAsync(GameObject icon)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_delayHideAnswerIcon));
        icon.SetActive(false);
        _barrier?.SetActive(false);
        OnHideAnswerIcon?.Invoke();
    }
}
