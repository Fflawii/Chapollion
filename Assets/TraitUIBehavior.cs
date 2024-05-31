using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace  Chapollion.ScriptableObjects.Data
{
    public class TraitUIBehavior : MonoBehaviour
    {
        public Library MyLibrary;
        public Chat MonChat;
        public bool IsQualite;
        public TMP_Dropdown MyDropdown;
        public TraitPrefabBehavior MyTraitPrefab;
        [SerializeField] private Transform ContentPanel;
        public List<TraitPrefabBehavior> Instances = new();
        public Button AddButton;
        public int MaxNBTrait = 3;


        void Start()
        {
            MonChat.OnRaceChanged.AddListener(RaceChanged);
            AddButton.onClick.AddListener(PlusClicked);
            MonChat.OnPointsDeCompetenceChanged.AddListener(CompetenceChanged);
            Populate();
        }

        private void CompetenceChanged(int arg0)
        {
            PointDeCompetences = arg0;
            Populate();
        }

        public int PointDeCompetences;


        private void PlusClicked()
        {
            var selectedTraitName = MyDropdown.captionText.text;
            var trait = FindTraitByName(selectedTraitName);
            AssignTraitToChat(trait);
            MonChat.CalculatePointsDeCompetence();
        }

        private Trait FindTraitByName(string traitName)
        {
            IEnumerable<Trait> traits = (IsQualite ? MyLibrary.QualitesDispo : MyLibrary.DefautsDispo);
            return traits.ToList().FirstOrDefault(t => t.Nom == traitName);
        }

        private void AssignTraitToChat(Trait trait)
        {
            if (trait == null) return;
            if (IsQualite)
            {
                MonChat.Qualites.Add((Qualite)trait);
            }
            else
            {
                MonChat.Defauts.Add((Default)trait);
            }
        }

        private void Populate()
        {
            if (MonChat.Race == null)
                return;
            foreach (var instance in Instances)
            {
                Destroy(instance.gameObject);
            }

            Instances.Clear();


            InstantiateTraits(IsQualite ? MonChat.Race.QualitésObligatoires : MonChat.Race.DefautsObligatoires, true);
            InstantiateTraits(IsQualite ? MonChat.Qualites : MonChat.Defauts, false);


            IEnumerable<Trait> MyLeftTraitToChoose = IsQualite ? MyLibrary.QualitesDispo : MyLibrary.DefautsDispo;
            var list = MyLeftTraitToChoose.ToList();
            foreach (var instance in Instances)
            {
                list.Remove(instance.trait);
            }

            var count = MonChat.Race.QualitésObligatoires.Count +
                        MonChat.Race.DefautsObligatoires.Count +
                        MonChat.Qualites.Count + MonChat.Defauts.Count;

            MyDropdown.interactable = (count < MaxNBTrait);
            AddButton.interactable = (count < MaxNBTrait);
            if (IsQualite)
            {
                list = list.Where(trait => PointDeCompetences + trait.gainPerte > 0).ToList();
            }

            MyDropdown.options.Clear();
            MyDropdown.AddOptions(list.Select(t => t.Nom).ToList());
        }

        private void RaceChanged(Race race)
        {
            Populate();
        }

        private void InstantiateTraits(IEnumerable<Trait> traits, bool isMandatory)
        {
            foreach (var trait in traits)
            {
                var traitObject = Instantiate(MyTraitPrefab, ContentPanel);
                Instances.Add(traitObject);
                traitObject.trait = trait;
                traitObject.IsMandatory = isMandatory;
                traitObject.MyCat = MonChat;
                traitObject.IsQualite = IsQualite;
                traitObject.OnEnable();
            }
        }
    }
}