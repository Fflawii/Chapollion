using System;
using Chapollion.ScriptableObjects.Services;
using UnityEngine;

namespace Chapollions.UI
{
    public class CharacterCreationBehavior : MonoBehaviour
    {
        [SerializeField] private CharacterCreationService MyCreationService;

        public void CreateCat()
        {
            MyCreationService.InitCat();
        }
        
        public void GenerateName()
        {
            MyCreationService.GenerateName();
        }
    }
}