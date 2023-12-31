using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    Vector2 _position;
    Transform _trans;
    int _currentTile = 1;
    bool _isPlayerTurn;
    
    private void Start()
    {
        _trans = GetComponent<Transform>();

        _position = _trans.position;

    }
    private void Update()
    {
        _trans.position = _position;
    }

    public Vector2 GetPosition()
    {
        return _position;
    }

    public bool GetIsPlayerTurn ()
    {
        return _isPlayerTurn;
    }

    public void setPosition(Vector2 pos)
    {
        _position = pos; 
    }

    public void setIsPlayerTurn(bool isTurn)
    {
        _isPlayerTurn = isTurn; 
    }

    public int getCurrentTile()
    {
        return _currentTile;
    }

    public void SetCurrentTile(int currentTile)
    {
        _currentTile = currentTile;
    }
}
