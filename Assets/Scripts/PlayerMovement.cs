using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    //InspectorValues
    [SerializeField] private List<Players> _player;
    public float speed;
    [SerializeField] private Board _board;
    [SerializeField] private Text _text;

    //positonal values

    Vector2 _currentPos;
    Vector2 _nextPos;

    //time veriables

    float _totalTime;
    float _deltaT;


    //Game turn data

    bool _isMoving;
    bool _gameIsOver;
    bool _turnStarted;

    //Current turn Information

    int _currentPlayer = 0;
    int _tileMovementAmount;

    //our die
    Dice _dice = new Dice();



    // Start is called before the first frame update
    void Start()
    {
        _board.InitTilePosition();
        _text.text = "Press 'space' to roll the die";

    }

    void CheckWin()
    {
        if (_gameIsOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Skinning");
        }
        if ((_player[0].getCurrentTile() == 100 || _player[1].getCurrentTile() == 100) && !_isMoving)
        {
            _gameIsOver = _turnStarted;
            _text.text = $"Game Over! Player {_currentPlayer + 1} Wins! Press 'Space' to play again";
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckWin();
        if (!_gameIsOver)
        {
            _currentPos = _player[_currentPlayer].GetPosition();

            if (_currentPlayer == 0)
            {
                _text.color = Color.magenta;

            }
            else
            {
                _text.color = Color.blue;
            }
            if (Input.GetKeyDown(KeyCode.Space) && _tileMovementAmount == 0)
            {
                _tileMovementAmount = _dice.RollDice();
                _text.text = "You rolled a " + _tileMovementAmount.ToString();
                _turnStarted = true;

            }
            if (_tileMovementAmount > 0 && !_isMoving)
            {
                MoveOneTile();
            }
            if (_isMoving)
            {
                UpdatePosition();
            }

            for (int i = 0; i < _board.GetSnakes().Count; i++)
            {
                if (_tileMovementAmount == 0 && _player[_currentPlayer].getCurrentTile() == _board.GetSnakes()[i].GetHeadTile())
                {
                    _tileMovementAmount = 1;
                    MoveDownSnake(i);
                }
            }

            for (int i = 0; i < _board.GetLadders().Count; i++)
            {
                if (_tileMovementAmount == 0 && _player[_currentPlayer].getCurrentTile() == _board.GetLadders()[i].getBottomTile())
                {
                    _tileMovementAmount = 1;
                    ClimbLadder(i);
                }
            }

            if (_tileMovementAmount == 0 && !_isMoving)
            {

                _text.text = " press 'Space' to roll the dice";
                

                if (_turnStarted)
                {
                    _turnStarted = false;

                    if (_currentPlayer == 0)
                    {
                        _currentPlayer = 1;

                    }
                    else
                    {
                        _currentPlayer = 0;
                    }
                }
            }
        }
    }

    void MoveOneTile()
    {
        _nextPos = _board.GetTilePositions()[_player[_currentPlayer].getCurrentTile()];
        _totalTime = (_nextPos - _currentPos / speed).magnitude;
        _isMoving = true;
        _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].getCurrentTile() + 1);

    }

    void UpdatePosition()
    {
        _deltaT += Time.deltaTime / _totalTime;
        if (_deltaT < 0f)
        {
            _deltaT = 0f;
        }

        if (_deltaT >= 1f || _nextPos == _currentPos)
        {
            _isMoving = false;
            _tileMovementAmount--;
            _deltaT = 0f;

        }
        _player[_currentPlayer].setPosition(Vector2.Lerp(_currentPos, _nextPos, _deltaT));
    }

    void MoveDownSnake(int slot)
    {
        _player[_currentPlayer].SetCurrentTile(_board.GetSnakes()[slot].GetTailTile()-1);
    }

    void ClimbLadder(int slot)
    {
        _player[_currentPlayer].SetCurrentTile(_board.GetLadders()[slot].getTopTile() - 1);

    }
}
