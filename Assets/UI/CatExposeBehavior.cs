using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Chapollion.ScriptableObjects.Data

{
public class CatExposeBehavior : MonoBehaviour
  
    {
     [SerializeField] private Chat myCat;
     [SerializeField] private Library myLib;
     [SerializeField] private UnityEvent<string> onCatNameChanged=new();
    
    private void OnEnable()
    {
        onCatNameChanged.Invoke(myCat.Nom);
        myCat.OnCatNameChanged.AddListener(CatNameChanged);
    } 

    public void GenerateName()
    {
        myCat.Nom = myLib.GenerateName();
    }  

    private void CatNameChanged(string aCatName)
    {
        onCatNameChanged.Invoke(aCatName);
    }

    private void OnDisable()
    {
        myCat.OnCatNameChanged.RemoveListener(CatNameChanged);
    }
    }

}