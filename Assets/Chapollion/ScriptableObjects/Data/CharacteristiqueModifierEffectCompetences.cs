using UnityEngine;
namespace  Chapollion.ScriptableObjects.Data 
 
 {
[CreateAssetMenu(fileName = "Effet_Competences")]
    public class CharacteristiqueModifierEffect : Effet
    {

        [SerializeField] private Charactéristique CharactéristiqueToAffect;
        [SerializeField][Range(-2,2)] private int valueToApply;
        
        public override void Apply(Chat aChat)
        {
            switch (CharactéristiqueToAffect)
            {
                case Charactéristique.Griffe:
                    aChat.Griffre += valueToApply;
                    break;
                case Charactéristique.Poil:
                    aChat.Poil += valueToApply;
                    break;
                case Charactéristique.Oeil:
                    aChat.Oeil += valueToApply;
                    break;
                case Charactéristique.Queue:
                    aChat.Queue += valueToApply;
                    break;
                case Charactéristique.Caresse:
                    aChat.Caresse += valueToApply;
                    break;
                case Charactéristique.Ronronnement:
                    aChat.Ronronnement += valueToApply;
                    break;
                case Charactéristique.Coussinet:
                    aChat.Coussinet += valueToApply;
                    break;
                case Charactéristique.Vibrisse:
                    aChat.Vibrisse += valueToApply;
                    break;
            }
        }
     }    
 }
 