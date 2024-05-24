using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FaceDetector : MonoBehaviour
{
    DiceRoll dice;

    private void Awake()
    {
        dice = FindObjectOfType<DiceRoll>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (dice != null)
        {
            if(dice.GetComponent<Rigidbody>().velocity.magnitude <= 0.01)
            {
                dice.diceFaceNum = (other.name);
            }
        }
    }

}
