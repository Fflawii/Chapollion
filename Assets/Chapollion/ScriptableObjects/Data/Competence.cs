using UnityEngine;
using UnityEngine.Events;
namespace  Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName="Competence")]

 public class Competence:NamedScriptableObject
    {
        [Range(0, 5)][SerializeField] public int _base;
        [Range(0, 5)][SerializeField] public int rang;
        [SerializeField] private Charactéristique CaracteristiquePrimareCalculBase;
        [SerializeField] private Charactéristique CaracteristiqueSecondaireCalculBase;

        public UnityEvent OnBaseChanged=new UnityEvent();
        

        public void CalulPointDeBase(Chat chat)
        {
            int primaryValue = chat.GetCharacteristique(CaracteristiquePrimareCalculBase);

            if (CaracteristiqueSecondaireCalculBase == Charactéristique.Aucune)
            {
                _base = primaryValue;
            }
            else
            {
                int secondaryValue = chat.GetCharacteristique(CaracteristiqueSecondaireCalculBase);
                _base = Mathf.RoundToInt((primaryValue + secondaryValue) / 2.0f);
            }
            OnBaseChanged.Invoke();
        }

        public void Initialize(Charactéristique primary, Charactéristique secondary)
        {
            CaracteristiquePrimareCalculBase = primary;
            CaracteristiqueSecondaireCalculBase = secondary;
        }
    }
}
