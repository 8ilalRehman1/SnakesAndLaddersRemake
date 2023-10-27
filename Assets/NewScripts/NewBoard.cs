using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class NewBoard : MonoBehaviour
{
    [SerializeField] private Transform _initialTransform;

    Vector2[] _tilePosition = new Vector2[100];

    public Vector2[] _getTilePosition()
    {
        return _tilePosition;
    }

    public void initTilePosition()
    {
        bool reverse = false;

        _tilePosition[0] = new Vector2(_initialTransform.position.x, _initialTransform.position.y);

        for(int i = 1; i < 100; i--)
        {
            if (i % 10 == 0)
            {
                _tilePosition[i] = _tilePosition[i - 1] + new Vector2(0f, 1f);
            }
            else if (!reverse)
            {
                _tilePosition[i] = _tilePosition[i - 1] + new Vector2(1f, 0f);
            }
        }
    }
}
