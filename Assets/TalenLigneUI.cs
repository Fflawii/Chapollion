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

    public Button IncreaseButtonT;
    public Button DecreaseButtonT;

   // public Competence competence;
   public Talent talent;
    public Chat chat;  // Référence à l'objet Chat pour mettre à jour les points de compétence restants

    private static readonly string[] NomsRangs = { "Éveillé", "Disciple", "Pratiquant", "Professeur", "Maître" };
    private static readonly int[] PointsDepense = { 1, 2, 4, 8, 16 };

     private bool listenersAdded = false;

    public void Start()
    {
        UpdateUI();
        if (!listenersAdded)
        {
        IncreaseButtonT.onClick.AddListener(IncreaseRang);
        DecreaseButtonT.onClick.AddListener(DecreaseRang);
        listenersAdded = true;
        }
    }

    public void UpdateUI()
    {
        MyTalTitle.text = talent.Nom;
        //MyTalBase.text = talent._base.ToString();
        MyTalRang.text = NomsRangs[talent.rang]; // Utilisation des noms de rangs
        MyTalCost.text = PointsDepense[talent.rang].ToString();
    }

    public void IncreaseRang()
    {
        if (talent.rang < PointsDepense.Length - 1)
        {
            int cost = PointsDepense[talent.rang + 1];
            if (chat.pointsDeTalentRestant >= cost)
            {
                chat.pointsDeTalentRestant -= cost;
                talent.rang++;
                UpdateUI();
                chat.OnPointsDeTalentChanged.Invoke(chat.pointsDeTalentRestant);
            }
        }
    }

    public void DecreaseRang()
    {
        if (talent.rang > 0)
        {
            int cost = PointsDepense[talent.rang];
            chat.pointsDeTalentRestant += cost;
            talent.rang--;
            UpdateUI();
            chat.OnPointsDeTalentChanged.Invoke(chat.pointsDeTalentRestant);
        }
    }
}
