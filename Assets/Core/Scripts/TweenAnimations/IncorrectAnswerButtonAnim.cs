using DG.Tweening;
using UnityEngine;

public class IncorrectAnswerButtonAnim : MonoBehaviour
{
    [SerializeField] private bool _isEnable;
    [SerializeField] private float _durationTime = 0.2f;
    [SerializeField] private float _shakeAngle = 5f;
    [SerializeField] private int _vibrato = 4;

    [SerializeField] private int _numberRepetitions;

    public void Play()
    {
        if (_isEnable)
        {
            Sequence sequence = DOTween.Sequence();

            sequence
                .Append(transform.DORotate(new Vector3(0, 0, _shakeAngle), _durationTime / 4).SetEase(Ease.InOutSine))
                .Append(transform.DORotate(new Vector3(0, 0, -_shakeAngle), _durationTime / 2).SetEase(Ease.InOutSine))
                .Append(transform.DORotate(Vector3.zero, _durationTime / 4).SetEase(Ease.InOutSine))
                .SetLoops(_numberRepetitions, LoopType.Restart);

            sequence.Play();
        }
    }
}
