using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using Chapollion.ScriptableObjects.Data;
public class TalenLigneUI : MonoBehaviour
{
     public TMP_Text MyTalTitle;
    //public TMP_Text MyTalBase;
    public TMP_Text MyTalRang;
    public TMP_Text MyTalCost;

    public Button IncreaseButton;
    public Button DecreaseButton;

   // public Competence competence;
   public Talent talent;
    public Chat chat;  // Référence à l'objet Chat pour mettre à jour les points de compétence restants

    private static readonly string[] NomsRangs = { "Éveillé", "Disciple", "Pratiquant", "Professeur", "Maître" };
    private static readonly int[] PointsDepense = { 1, 2, 4, 8, 16 };

    public void Start()
    {
        UpdateUI();
        IncreaseButton.onClick.AddListener(IncreaseRang);
        DecreaseButton.onClick.AddListener(DecreaseRang);
    }

    public void UpdateUI()
    {
        MyTalTitle.text = talent.nom;
        //MyTalBase.text = talent._base.ToString();
        MyTalRang.text = NomsRangs[talent.rang]; // Utilisation des noms de rangs
        MyTalCost.text = PointsDepense[talent.rang].ToString();
    }

    public void IncreaseRang()
    {
        if (talent.rang < PointsDepense.Length - 1)
        {
            int cost = PointsDepense[talent.rang + 1];
            if (chat.pointsDeCompetencenRestant >= cost)
            {
                chat.pointsDeCompetencenRestant -= cost;
                talent.rang++;
                UpdateUI();
                chat.OnPointsDeCompetenceChanged.Invoke(chat.pointsDeCompetencenRestant);
            }
        }
    }

    public void DecreaseRang()
    {
        if (talent.rang > 0)
        {
            int cost = PointsDepense[talent.rang];
            chat.pointsDeCompetencenRestant += cost;
            talent.rang--;
            UpdateUI();
            chat.OnPointsDeCompetenceChanged.Invoke(chat.pointsDeCompetencenRestant);
        }
    }
}
