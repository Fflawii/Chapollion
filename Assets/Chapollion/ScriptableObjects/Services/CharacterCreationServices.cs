using UnityEngine;
using System.Collections.Generic;


namespace  Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName="creation ", menuName="Service/Character creation  service", order=0)]

    public class CharacterCreationService : ScriptableObject
    {
        [SerializeField] private Library myLibrary;
        [SerializeField] private Chat myCurrentCat;
      
        private void OnEnable()
        {
            InitCat();
        }

        [ContextMenu("Créer un nouveau chat")]
        private void InitCat()
        {
    
            myCurrentCat.Init(myLibrary.GetDefaultCompetencesCopy(),GenerateName(),GenerateLignee());
        }

        private string GenerateLignee()
        {
            return myLibrary.GenerateLignee();
        }

        private string GenerateName()
        {
            return myLibrary.GenerateName();
        }

        public int ConvertHumanAgeToCat(int humanAge)
        {
            return Mathf.RoundToInt(humanAge / 5.0f);
        }
    }
}