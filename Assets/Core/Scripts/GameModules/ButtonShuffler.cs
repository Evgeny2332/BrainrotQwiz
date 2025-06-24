using System.Collections.Generic;
using UnityEngine;

public class ButtonShuffler : MonoBehaviour
{
    #region Fields
    [SerializeField] private List<Transform> _buttonsTransform;
    #endregion

    public void Shuffle()
    {
        List<Vector3> positions = new List<Vector3>();

        foreach (var button in _buttonsTransform)
            positions.Add(button.position);

        for (int i = positions.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            Vector3 temp = positions[i];
            positions[i] = positions[j];
            positions[j] = temp;
        }

        for(int i = 0;  i < _buttonsTransform.Count; i++)
            _buttonsTransform[i].position = positions[i];
    }
}
