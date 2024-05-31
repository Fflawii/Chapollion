using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private DiceRoll dice6;
    private DiceRoll dice10;

    [SerializeField]
    private TMP_Text scoreTextDice6;
    [SerializeField]
    private TMP_Text scoreTextDice10;

    private void Awake()
    {
        DiceRoll[] diceRolls = FindObjectsOfType<DiceRoll>();
        foreach (var dice in diceRolls)
        {
            if (dice.GetDiceType() == "dice6")
            {
                dice6 = dice;
            }
            else if (dice.GetDiceType() == "dice10")
            {
                dice10 = dice;
            }
        }
    }

    private void Update()
    {
        if (dice6 != null && !string.IsNullOrEmpty(dice6.diceFaceNum))
        {
            scoreTextDice6.text = dice6.diceFaceNum;
        }

        if (dice10 != null && !string.IsNullOrEmpty(dice10.diceFaceNum))
        {
            scoreTextDice10.text = dice10.diceFaceNum;
        }
    }
}
