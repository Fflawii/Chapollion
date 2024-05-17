using UnityEngine;
using System.Collections.Generic;


namespace  Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName="creation ", menuName="Service/Character creation  service", order=0)]

 public class CharacterCreationServices:ScriptableObject
    {
        [SerializeField] private Library myLibrary; 
        [SerializeField] private Chat myCurrentCat; 
    }

    private void OnEnable()
    {
        IniCat();
    }

    private void IniCat()
    {
        myCurrentCat.Init(myLibrary.competenceDispo);
    }

}