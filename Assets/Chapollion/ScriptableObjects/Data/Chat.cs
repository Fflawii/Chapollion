using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "Chat", menuName = "Create Cat", order = 0)]
    public class Chat : ScriptableObject
    {
        [SerializeField] private string nom;
        public UnityEvent<string> OnCatNameChanged = new();

        [SerializeField] private string pseudo;

        [SerializeField] private Sprite portrait;

        [Range(1, 20)] [SerializeField] private int age;
        [SerializeField] private Race race;
        [SerializeField] private string lignee;
        public UnityEvent<string> OnCatLigneeChanged = new();

        [SerializeField] private int reputation = 0;
        [SerializeField] private Faction faction;


        [SerializeField] private List<Qualite> qualites = new();
        [SerializeField] private List<Default> defauts = new();

        [SerializeField] private int pointsDeCreation;
        [SerializeField] private int pointsDeCreationRestant;
        public UnityEvent<int> OnPointsDeCreationRestantChanged = new();

        [SerializeField] private int pointsDeCompetence;
        [SerializeField] private int pointsDeCompetencenRestant;
        public UnityEvent<int> OnPointsDeCompetenceChanged = new();


        [Header("Physique")] [Range(1, 5)] [SerializeField]
        private int griffre = 1;

        [Range(1, 5)] [SerializeField] private int poil = 1;

        [Range(1, 5)] [SerializeField] private int oeil = 1;

        [Range(1, 5)] [SerializeField] private int queue = 1;


        [Header("Mental")] [Range(1, 5)] [SerializeField]
        private int caresse = 1;

        [Range(1, 5)] [SerializeField] private int ronronnement = 1;

        [Range(1, 5)] [SerializeField] private int coussinet = 1;

        [Range(1, 5)] [SerializeField] private int vibrisse = 1;

        [Header("Chance")] [Range(1, 3)] [SerializeField]
        private int chance = 1;

        [Header("Compétences")] [SerializeField]
        private List<Competence> competences = new();

        [Header("Talents")] [SerializeField] private List<Talent> talents = new();

        public void CalculatePointsDeCompetence()
        {
            pointsDeCompetence = (Ronronnement + caresse) * 3;
            Debug.Log( "1 " + pointsDeCompetence);
            if (Race != null)
            {
                if (Race.DefautsObligatoires != null)
                    pointsDeCompetence += CalculateSommeTrait(Race.DefautsObligatoires.OfType<Trait>().ToList());
                if (Race.QualitésObligatoires != null)
                    pointsDeCompetence += CalculateSommeTrait(Race.QualitésObligatoires.OfType<Trait>().ToList());
            }
            Debug.Log( "2 " + pointsDeCompetence);
            if (defauts != null) pointsDeCompetence += CalculateSommeTrait(defauts.OfType<Trait>().ToList());
            if (qualites != null) pointsDeCompetence += CalculateSommeTrait(qualites.OfType<Trait>().ToList());
            Debug.Log( "3 " + pointsDeCompetence);
            OnPointsDeCompetenceChanged.Invoke(pointsDeCompetence);
        }

        public int CalculateSommeTrait(List<Trait> listTrait)
        {
            int i = 0;

            foreach (var trait in listTrait)
            {
                i += trait.gainPerte;
            }

            return i;
        }

        public int Griffre
        {
            get => griffre;
            set
            {
                if (griffre == value) return;
                griffre = value;
                CalculatePointsRestants();
            }
        }

        public int Poil
        {
            get => poil;
            set
            {
                if (poil == value) return;
                poil = value;
                CalculatePointsRestants();
            }
        }

        public int Oeil
        {
            get => oeil;
            set
            {
                if (oeil == value) return;
                oeil = value;
                CalculatePointsRestants();
            }
        }

        public int Queue
        {
            get => queue;
            set
            {
                if (queue == value) return;
                queue = value;
                CalculatePointsRestants();
            }
        }

        public int Caresse
        {
            get => caresse;
            set
            {
                if (caresse == value) return;
                caresse = value;
                CalculatePointsRestants();
            }
        }

        public int Ronronnement
        {
            get => ronronnement;
            set
            {
                if (ronronnement == value) return;
                ronronnement = value;
                CalculatePointsRestants();
            }
        }

        public int Coussinet
        {
            get => coussinet;
            set
            {
                if (coussinet == value) return;
                coussinet = value;
                CalculatePointsRestants();
            }
        }

        public int Vibrisse
        {
            get => vibrisse;
            set
            {
                if (vibrisse == value) return;
                vibrisse = value;
                CalculatePointsRestants();
            }
        }

        public string Nom
        {
            get => nom;
            set
            {
                if (nom == value) return;
                nom = value;
                CalculatePointsRestants();
                OnCatNameChanged.Invoke(nom);
            }
        }

        public string Lignee
        {
            get => lignee;
            set
            {
                if (lignee == value) return;
                lignee = value;
                CalculatePointsRestants();
                OnCatLigneeChanged.Invoke(lignee);
            }
        }

        public int Chance
        {
            get => chance;
            set
            {
                if (chance == value) return;
                chance = value;
                CalculatePointsRestants();
            }
        }

        public int PointsDeCreationRestant
        {
            get => pointsDeCreationRestant;
            set
            {
                if (pointsDeCreationRestant == value) return;
                pointsDeCreationRestant = value;
                OnPointsDeCreationRestantChanged.Invoke(pointsDeCreationRestant);
            }
        }

        public Race Race
        {
            get => race;
            set
            {
                race = value;
                CalculatePointsDeCompetence();
            }
        }


        public void Init(List<Competence> defaultCompetences, string aName, string aLignee, int aPointsDeCreation)
        {
            Nom = aName;
            pseudo = string.Empty;
            portrait = null;
            age = 7;
            Race = null;
            Lignee = aLignee;
            reputation = 0;
            faction = null;
            qualites = new List<Qualite>();
            defauts = new List<Default>();
            pointsDeCreation = aPointsDeCreation;
            pointsDeCompetence = 0;
            Griffre = 1;
            Poil = 1;
            Oeil = 1;
            Queue = 1;

            Caresse = 1;
            Ronronnement = 1;
            Coussinet = 1;
            Vibrisse = 1;

            Chance = 1;
            CalculatePointsRestants();

#if UNITY_EDITOR
            foreach (var competence in competences)
            {
                UnityEditor.AssetDatabase.RemoveObjectFromAsset(competence);
            }
#endif

            competences = defaultCompetences;
#if UNITY_EDITOR

            foreach (var competence in competences)
            {
                competence.name = competence.name.Replace("(Clone)", string.Empty);
                competence.OnEnable();
                UnityEditor.AssetDatabase.AddObjectToAsset(competence, this);
                UnityEditor.EditorUtility.SetDirty(competence);
            }

            UnityEditor.EditorUtility.SetDirty(this);

            // Save all changes to disk
            // UnityEditor.AssetDatabase.SaveAssets();
#endif
            talents = new List<Talent>();
        }

        private void CalculatePointsRestants()
        {
            PointsDeCreationRestant = pointsDeCreation - (Griffre +
                                                          Poil +
                                                          Oeil +
                                                          Queue +
                                                          Caresse +
                                                          Ronronnement +
                                                          Coussinet +
                                                          Vibrisse +
                                                          Chance);
            CalculatePointsDeCompetence();
        }

        public int GetCharacteristique(Charactéristique cara)
        {
            switch (cara)
            {
                case Charactéristique.Griffe:
                    return Griffre;
                case Charactéristique.Poil:
                    return Poil;
                case Charactéristique.Oeil:
                    return Oeil;
                case Charactéristique.Queue:
                    return Queue;
                case Charactéristique.Caresse:
                    return Caresse;
                case Charactéristique.Ronronnement:
                    return Ronronnement;
                case Charactéristique.Coussinet:
                    return Coussinet;
                case Charactéristique.Vibrisse:
                    return Vibrisse;
                case Charactéristique.Chance:
                    return Chance;
            }

            return 0;
        }

        public void SetCharacteristique(Charactéristique cara, int point)
        {
            switch (cara)
            {
                case Charactéristique.Griffe:
                    Griffre = point;
                    break;
                case Charactéristique.Poil:
                    Poil = point;
                    break;
                case Charactéristique.Oeil:
                    Oeil = point;
                    break;
                case Charactéristique.Queue:
                    Queue = point;
                    break;
                case Charactéristique.Caresse:
                    Caresse = point;
                    break;
                case Charactéristique.Ronronnement:
                    Ronronnement = point;
                    break;
                case Charactéristique.Coussinet:
                    Coussinet = point;
                    break;
                case Charactéristique.Vibrisse:
                    Vibrisse = point;
                    break;
                case Charactéristique.Chance:
                    Chance = point;
                    break;
            }

            CalculatePointsRestants();
        }
    }
}