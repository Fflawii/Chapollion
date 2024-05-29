using UnityEngine;
namespace  Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName="Competence")]

 public class Competence:NamedScriptableObject
    {
        [SerializeField][TextArea(3, 15)] private string description;
        [Range(0,5)] [SerializeField] private int babase;
        [Range(0,5)] [SerializeField] private int rang;

        [SerializeField] private Charactéristique CaracteristiquePrimareCalculBase;
        [SerializeField] private Charactéristique CaracteristiqueSecondaireCalculBase;

         public void CalulPointDeBase(Chat chat)
        {
            int result = chat.GetCharacteristique(CaracteristiquePrimareCalculBase);
            if (CaracteristiqueSecondaireCalculBase == Charactéristique.Aucune)
            {
                babase = result;
                return;
            }

            result += chat.GetCharacteristique(CaracteristiqueSecondaireCalculBase);
            babase = Mathf.RoundToInt(result / 2.0f);
        }
    }

}