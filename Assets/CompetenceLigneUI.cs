using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using Chapollion.ScriptableObjects.Data;
using System;

public class CompetenceLigneUI : MonoBehaviour
{
    public TMP_Text MyCompTitle;
    public TMP_Text MyCompBase;
    public TMP_Text MyCompRang;
    public TMP_Text MyCompCost;

    public Button IncreaseButtonC;
    public Button DecreaseButtonC;

    public Competence competence;
    public Chat chat;  

    private static readonly string[] NomsRangs = { "Néophyte", "Amateur", "Connaisseur", "Professionnel", "Expert", "Maître" };
    private static readonly int[] PointsDepense = { 0, 1, 2, 4, 8, 16 };

    private bool listenersAdded = false;

    public void Start()
    {
        UpdateUI();
        if (!listenersAdded)
        {
        IncreaseButtonC.onClick.AddListener(IncreaseRangC);
        DecreaseButtonC.onClick.AddListener(DecreaseRangC);
        listenersAdded = true;
        }
        competence.OnBaseChanged.AddListener(UpdateUI);

    }

    private void OnDisable()
    {
        IncreaseButtonC.onClick.RemoveListener(IncreaseRangC);
        DecreaseButtonC.onClick.RemoveListener(DecreaseRangC);
    }


    public void UpdateUI()
    {
        MyCompTitle.text = competence.Nom;
        MyCompBase.text = competence._base.ToString();
        MyCompRang.text = NomsRangs[competence.rang]; // Utilisation des noms de rangs
        MyCompCost.text = PointsDepense[competence.rang].ToString();


        /*
        var point = PointsDepense[competence.rang];
        Debug.Log("AAAAAAAAAAAAA ICI "+point);
        var pointMax = 16;

        DecreaseButtonC.interactable = point != 1;

        if (point < 1)
        {
            DecreaseButtonC.interactable = false;
        }
        else if (point == pointMax)
        {
            IncreaseButtonC.interactable = false;
        }
        else
        {
            IncreaseButtonC.interactable = true;
        }*/
    }

    public void IncreaseRangC()
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

    public void DecreaseRangC()
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
