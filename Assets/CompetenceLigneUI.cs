using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using Chapollion.ScriptableObjects.Data;

public class CompetenceLigneUI : MonoBehaviour
{
    public TMP_Text MyCompTitle;
    public TMP_Text MyCompBase;
    public TMP_Text MyCompRang;
    public TMP_Text MyCompCost;

    public Button IncreaseButton;
    public Button DecreaseButton;

    public Competence competence;
    public Chat chat;  // Référence à l'objet Chat pour mettre à jour les points de compétence restants

    private static readonly string[] NomsRangs = { "Néophyte", "Amateur", "Connaisseur", "Professionnel", "Expert", "Maître" };
    private static readonly int[] PointsDepense = { 0, 1, 2, 4, 8, 16 };

    public void Start()
    {
        UpdateUI();
        IncreaseButton.onClick.AddListener(IncreaseRang);
        DecreaseButton.onClick.AddListener(DecreaseRang);
    }

    public void UpdateUI()
    {
        MyCompTitle.text = competence.Nom;
        MyCompBase.text = competence._base.ToString();
        MyCompRang.text = NomsRangs[competence.rang]; // Utilisation des noms de rangs
        MyCompCost.text = PointsDepense[competence.rang].ToString();
    }

    public void IncreaseRang()
    {
        if (competence.rang < PointsDepense.Length - 1)
        {
            int cost = PointsDepense[competence.rang + 1];
            if (chat.pointsDeCompetencenRestant >= cost)
            {
                chat.pointsDeCompetencenRestant -= cost;
                competence.rang++;
                UpdateUI();
                chat.OnPointsDeCompetenceChanged.Invoke(chat.pointsDeCompetencenRestant);
            }
        }
    }

    public void DecreaseRang()
    {
        if (competence.rang > 0)
        {
            int cost = PointsDepense[competence.rang];
            chat.pointsDeCompetencenRestant += cost;
            competence.rang--;
            UpdateUI();
            chat.OnPointsDeCompetenceChanged.Invoke(chat.pointsDeCompetencenRestant);
        }
    }
}
