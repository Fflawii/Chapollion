using Koboct.ScriptableObjects.Services;
using UnityEngine;

namespace Koboct.UI
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