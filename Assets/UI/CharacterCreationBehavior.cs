using System;
using System.Collections;
using System.Collections.Generic;
using Chapollion.ScriptableObjects.Services;
using UnityEngine;

namespace Chapollion.ScriptableObjects.Data

{
    public class CharacterCreationBehavior : MonoBehaviour
    {
        [SerializeField] private CharacterCreationService MyCreationService;

        public void CreateCat()

        {
            MyCreationService.InitCat();
        }

    }
}
