using UnityEngine;

public class ResultGame : MonoBehaviour
{
    [SerializeField] private GameObject _resultWindow;

    public void Enable()
    {
        _resultWindow.SetActive(true);
    }
    public void Disable()
    {
        _resultWindow.SetActive(false);
    }
}
