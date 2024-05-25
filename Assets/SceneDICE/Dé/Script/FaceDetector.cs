using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDetector : MonoBehaviour
{
    private Dictionary<string, string[]> diceFaceTexts = new Dictionary<string, string[]>()
    {
        { "dice6", new string[] { "fines", "musclées", "large", "poilu", "bondissante", "grosse" } },
        { "dice10", new string[] { "cou", "cuisse", "dent", "oreille", "dos", "griffes", "pattes", "queue", "tête", "yeux" } }
    };

    private void OnTriggerStay(Collider other)
    {
        DiceRoll diceRoll = other.GetComponentInParent<DiceRoll>();
        if (diceRoll != null && diceRoll.GetComponent<Rigidbody>().velocity.magnitude <= 0.01)
        {
            string diceType = diceRoll.GetDiceType();
            int faceIndex;
            if (int.TryParse(other.name, out faceIndex))
            {
                faceIndex -= 1; // assuming face names are "1", "2", ..., "6" or "10"
                if (faceIndex >= 0 && faceIndex < diceFaceTexts[diceType].Length)
                {
                    diceRoll.diceFaceNum = diceFaceTexts[diceType][faceIndex];
                    Debug.Log($"Detected face {faceIndex + 1} on {diceType}: {diceRoll.diceFaceNum}");
                }
            }
        }
    }
}
