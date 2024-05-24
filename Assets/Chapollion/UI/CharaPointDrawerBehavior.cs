using System;
using Chapollion.ScriptableObjects.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharaPointDrawerBehavior : MonoBehaviour
{
    public Chat MyCat;

    public TMP_Text CharaText;
    public TMP_Text CharaChiffre;

    public Button PlusButton;
    public Button MinusButton;


    public Charactéristique MyChara;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        CharaText.text = Enum.GetName(typeof(Charactéristique), MyChara);
        UpdateText();
        PlusButton.onClick.AddListener(Plus);
        MinusButton.onClick.AddListener(Minus);
        MyCat.OnPointsDeCreationRestantChanged.AddListener(UpdateText);
    }

    private void UpdateText(int i = 0)
    {
        var point = MyCat.GetCharacteristique(MyChara);
        var pointMax = MyChara == Charactéristique.Chance ? 3 : 5;
        CharaChiffre.text = point.ToString();

        MinusButton.interactable = point != 1;

        if (MyCat.PointsDeCreationRestant < 1)
        {
            PlusButton.interactable = false;
        }
        else if (point == pointMax)
        {
            PlusButton.interactable = false;
        }
        else
        {
            PlusButton.interactable = true;
        }
    }

    private void OnDisable()
    {
        PlusButton.onClick.RemoveListener(Plus);
        MinusButton.onClick.RemoveListener(Minus);
    }

    private void Minus()
    {
        var point = MyCat.GetCharacteristique(MyChara);
        MyCat.SetCharacteristique(MyChara, point - 1);
    }


    private void Plus()
    {
        var point = MyCat.GetCharacteristique(MyChara);
        MyCat.SetCharacteristique(MyChara, point + 1);
    }
}