using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Ladders : MonoBehaviour
{
    [SerializeField] private int _topTile;
    [SerializeField] private int _bottomTile;
    public Ladders(int topTile, int bottomTile)
    {
        _topTile = topTile;
        _bottomTile = bottomTile;
    }
    public int getTopTile()
    { 
        return _topTile;
    }

    public int getBottomTile() 
    { 
        return _bottomTile; 
    }

}
