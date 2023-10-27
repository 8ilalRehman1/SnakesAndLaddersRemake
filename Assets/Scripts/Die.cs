using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int RollDice()
    {
        float diceRoll = Random.Range(1, 6);
        return (int)diceRoll;
    }
}
