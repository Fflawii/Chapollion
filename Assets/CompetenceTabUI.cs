using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Chapollion.ScriptableObjects.Data;

public class CompetenceTabUI : MonoBehaviour
{
    public Chat MonChat;
    public CompetenceLigneUI MonPrefab;
    public Transform Father;

    void OnEnable()
    {
        MonChat.CalculatePointsDeCompetence(); // Assurez-vous de calculer les compétences avant de les afficher
        foreach (var comp in MonChat.competences)
        {
            var compUI = Instantiate(MonPrefab, Father);
            compUI.competence = comp;
            compUI.chat = MonChat;  // Passez la référence du Chat ici
            compUI.Start();
        }
    }
}
