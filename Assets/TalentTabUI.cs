using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Chapollion.ScriptableObjects.Data;

public class TalentTabUI : MonoBehaviour
{
    public Chat MonChat;
    public TalenLigneUI MonPrefab;
    public Transform Father;

    void OnEnable()
    {
        MonChat.CalculateTalentsPoints(); 
        foreach (var comp in MonChat.talents)
        {
            var compUI = Instantiate(MonPrefab, Father);
            compUI.talent = comp;
            compUI.chat = MonChat;  
            compUI.Start();
        }
    }
}
