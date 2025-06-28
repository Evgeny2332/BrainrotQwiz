using DG.Tweening;
using UnityEngine;

public class CorrectAnswerButtonAnim : MonoBehaviour
{
    [SerializeField] private bool _isEnable;

    [SerializeField] private float _durationTime;

    public void Play()
    {
        if (_isEnable)
        {
            Sequence sequence = DOTween.Sequence();

            sequence
                .Append(transform.DOScale(1.1f, _durationTime / 2).SetEase(Ease.OutSine))
                .Append(transform.DOScale(1f, _durationTime / 2).SetEase(Ease.InSine));

            sequence.Play();
        }
    }
}
