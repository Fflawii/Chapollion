using System;
using System.Collections;
using System.Collections.Generic;
using Chapollion.ScriptableObjects.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FactionDropDown : MonoBehaviour
{
    public Library library;

    public TMP_Dropdown dropdown;

    public UnityEvent<string> DescriptionChanged = new();   
    void Start()
    {
        dropdown.ClearOptions();
        var t=new List<string>();
        foreach (var faction in library.factionsDispo)
        {
            t.Add(faction.name);
        }
        dropdown.AddOptions(t);
        dropdown.onValueChanged.AddListener(Changed);
        Changed(0);
    }

    private void Changed(int arg0)
    {
        DescriptionChanged.Invoke(library.factionsDispo[arg0].Description);


    }
}
