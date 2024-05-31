using UnityEngine;
﻿using Chapollion.ScriptableObjects.Data;
using System.Collections.Generic;


namespace  Chapollion.ScriptableObjects.Services
{
    [CreateAssetMenu(fileName="creation ", menuName="Service/Character creation  service", order=0)]

   public class CharacterCreationService : ScriptableObject
    {
        [SerializeField] private Library myLibrary;
        [SerializeField] private Chat myCurrentCat;
        [Range(20, 28)] [SerializeField] private int _pointsCreationIntialChat;
        public void OnEnable()
        {
            InitCat();
        }

        [ContextMenu("Créer un nouveau chat")]
        public void InitCat()
        {
    
            myCurrentCat.Init(myLibrary.GetDefaultCompetencesCopy(),GenerateName(),GenerateLignee(),_pointsCreationIntialChat,myLibrary.GetDefaultTalentsCopy());
        }

        private string GenerateLignee()
        {
            return myLibrary.GenerateLignee();
        }

        public string GenerateName()
        {
            return myLibrary.GenerateName();
        }

        public int ConvertHumanAgeToCat(int humanAge)
        {
            return Mathf.RoundToInt(humanAge / 5.0f);
        }
    }
}