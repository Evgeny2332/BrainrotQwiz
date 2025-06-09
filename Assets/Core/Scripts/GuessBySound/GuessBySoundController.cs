using UnityEngine;

public class GuessBySoundController : MonoBehaviour
{
    #region Field
    [SerializeField] private SoundBlock _soundBlock;
    #endregion

    #region MonoBehaviour
    private void Awake()
    {
        _soundBlock.Init();
    }
    #endregion
}
