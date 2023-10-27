using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Board : MonoBehaviour
{
    [SerializeField] private Transform _initialTransform;
    [SerializeField] private List<Snake> _snakes;
    [SerializeField] private List<Ladders> _ladders;

    Vector2[] _tilePosition = new Vector2[100];

    public List<Snake> GetSnakes() 
    { 
        return _snakes; 
    }

    public List<Ladders> GetLadders() 
    {  
        return _ladders; 
    }

    public Vector2[] GetTilePositions()
    {
        return _tilePosition;
    }

   public void InitTilePosition()
    {
        bool reverse = false;

        _tilePosition[0] = new Vector2(_initialTransform.position.x, _initialTransform.position.y);

        for (int i = 1; i < 100; i++)
        {
            if (i % 10 == 0)
            {
                _tilePosition[i] = _tilePosition[i - 1] + new Vector2(0f, 1f);
            }
            else if (!reverse)
            {
                _tilePosition[i] = _tilePosition[i - 1] + new Vector2(1f, 0f);
            }
            else if (reverse)
            {
                _tilePosition[i] = _tilePosition[i - 1] + new Vector2 (-1f, 0f);
            }

            if((i + 1) % 10 == 0)
            {
                reverse = !reverse;
            }
        }
    }
}
