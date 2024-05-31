using UnityEngine;
using System.Collections.Generic;


namespace  Chapollion.ScriptableObjects.Data
{
     [CreateAssetMenu(fileName = "Game Library", menuName = "Create Game Library", order = 0)]
   public class Library : ScriptableObject
    {
        [SerializeField] private DiceResultsService myDice;

        [SerializeField] private List<string> prefixNomDispo = new();
        [SerializeField] private List<string> suffixNomDispo = new();
      
        [SerializeField] private List<Lignee> lignees = new();
     
        [SerializeField] private List<Faction> factionsDispo = new();

        [SerializeField] private List<Qualite> qualitesDispo = new();
        [SerializeField] private List<Default> defautsDispo = new();

        [SerializeField] private List<Competence> competencesDispo = new();
        [SerializeField] private List<Talent> talentsDispo = new();


        [SerializeField] private List<Race> racesDispo = new();

        public List<Race> RacesDispo
        {
            get => racesDispo;
            set => racesDispo = value;
        }
        public List<Competence> GetDefaultCompetencesCopy()
        {
            var defaut = new List<Competence>();
            foreach (var competence in competencesDispo)
            {
                defaut.Add(Instantiate(competence));
            }

            return defaut;
        }

        public List<Talent> GetDefaultTalentsCopy()
        {
            var defaut = new List<Talent>();
            foreach (var talent in talentsDispo)
            {
                defaut.Add(Instantiate(talent));
            }

            return defaut;
        }

        public string GenerateName()
        {
            return $"{prefixNomDispo[myDice.LaunchD10() - 1]} {suffixNomDispo[myDice.LaunchD10() - 1]}";
        }
        
        public string GenerateLignee()
        {
            var prefix = lignees[myDice.LaunchD6(2) - 2];
            var suffix = prefix.Suffixes[myDice.LaunchD6() - 1];
            if (suffix.Invert)
                return $"{suffix.Nom}  {prefix.Nom}";
            return $"{prefix.Nom} {suffix.Nom}";
        }
    }
}