using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace  Chapollion.ScriptableObjects.Data
{
    public class TraitPrefabBehavior : MonoBehaviour
    {
        public bool IsMandatory;
        public Trait trait;
        public bool IsQualite;
        [SerializeField] private TMP_Text MyText;
        public UnityEvent<bool> IsNotMandatory = new();
        public Button MinusButton;
        public Chat MyCat;
        public void OnEnable()
        {
            if (trait != null) MyText.text = trait.Nom;
            IsNotMandatory.Invoke(!IsMandatory);
            MinusButton.onClick.AddListener(Clicked);
        }

        private void Clicked()
        {
            if (IsQualite)
                MyCat.Qualites.Remove(trait as Qualite);
            else
                MyCat.Defauts.Remove(trait as Default);
            MyCat.CalculatePointsDeCompetence();
        }
    }
}