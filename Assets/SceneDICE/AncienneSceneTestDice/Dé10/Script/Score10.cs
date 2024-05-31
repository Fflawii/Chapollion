using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score10 : MonoBehaviour
{
   public DiceRoll dice;

    [SerializeField]
    TMP_Text scoreText;
    private void Awake()
    {
        //dice = FindObjectOfType<DiceRoll>();
    }

    private void Update()
    {
        if (dice != null)
        {
            if (dice.diceFaceNum != "")
            {
                scoreText.text = dice.diceFaceNum;
            }
        }
    }
}
