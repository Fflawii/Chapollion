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

        [Range(1, 20)][SerializeField] private int age;
        [SerializeField] private Race race;
        public UnityEvent<Race> OnRaceChanged = new();
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
        [SerializeField] public int pointsDeCompetencenRestant;

        public UnityEvent<int> OnPointsDeCompetenceChanged = new();

        [SerializeField] private int pointsDeTalent;
        [SerializeField] public int pointsDeTalentRestant;

        public UnityEvent<int> OnPointsDeTalentChanged = new();


        [Header("Physique")]
        [Range(1, 5)]
        [SerializeField]
        private int griffre = 1;

        [Range(1, 5)][SerializeField] private int poil = 1;

        [Range(1, 5)][SerializeField] private int oeil = 1;

        [Range(1, 5)][SerializeField] private int queue = 1;

        [Header("Mental")]
        [Range(1, 5)]
        [SerializeField]
        private int caresse = 1;

        [Range(1, 5)][SerializeField] private int ronronnement = 1;

        [Range(1, 5)][SerializeField] private int coussinet = 1;

        [Range(1, 5)][SerializeField] private int vibrisse = 1;

        [Header("Chance")]
        [Range(1, 3)]
        [SerializeField]
        private int chance = 1;

        [Header("Compétences")]
        [SerializeField]
        public List<Competence> competences = new();

        [Header("Talents")]
        [SerializeField]
        public List<Talent> talents = new();

        private static readonly int[] PointsDepense = { 0, 1, 2, 4, 8, 16 };

        public void CalculatePointsDeCompetence()
        {
            pointsDeCompetence = (Ronronnement + Caresse) * 3;
            pointsDeCompetencenRestant=pointsDeCompetence;
            OnPointsDeCompetenceChanged.Invoke(pointsDeCompetencenRestant);
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
                CalculateTalentsPoints();

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
                if (race==value) return;
               
                race = value;
                Qualites = new List<Qualite>();
                Defauts = new List<Default>();
                OnRaceChanged.Invoke(race);
                CalculatePointsDeCompetence();
            }
        }

        public List<Qualite> Qualites
        {
            get => qualites;
            set => qualites = value;
        }

        public List<Default> Defauts
        {
            get => defauts;
            set => defauts = value;
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
            Qualites = new List<Qualite>();
            Defauts = new List<Default>();
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
            UpdateCompetenceValues();

#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                foreach (var competence in competences)
                {
                    UnityEditor.AssetDatabase.RemoveObjectFromAsset(competence);
                }



                competences = new List<Competence>();

                foreach (var competence in defaultCompetences)
                {
                    var newCompetence = Instantiate(competence);
                    newCompetence.name = competence.name.Replace("(Clone)", string.Empty);
                    competences.Add(newCompetence);
                    newCompetence.OnEnable();
                    UnityEditor.AssetDatabase.AddObjectToAsset(newCompetence, this);
                    UnityEditor.EditorUtility.SetDirty(newCompetence);
                }

                UnityEditor.EditorUtility.SetDirty(this);
                // Save all changes to disk
                UnityEditor.AssetDatabase.SaveAssets();


                foreach (var talent in talents)
                {
                    UnityEditor.AssetDatabase.RemoveObjectFromAsset(talent);
                }

                talents = new List<Talent>();
                


                foreach (var talent in defaultTalents)
                {
                    var newTalent = Instantiate(talent);
                    newTalent.name = talent.name.Replace("(Clone)", string.Empty);
                    talents.Add(newTalent);
                    newTalent.OnEnable();
                    UnityEditor.AssetDatabase.AddObjectToAsset(newTalent, this);
                    UnityEditor.EditorUtility.SetDirty(newTalent);
                }

                UnityEditor.EditorUtility.SetDirty(this);
                // Save all changes to disk
                UnityEditor.AssetDatabase.SaveAssets();
            }
#endif
        }

        private void UpdateCompetenceValues()
        {
            foreach (var competence in competences)
            {
                competence.CalulPointDeBase(this);
            }
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
               UpdateCompetenceValues();
        }

        public bool DepensePointsDeCompetence(int points)
        {
            if (pointsDeCompetencenRestant >= points)
            {
                pointsDeCompetencenRestant -= points;
                OnPointsDeCompetenceChanged.Invoke(pointsDeCompetencenRestant);
                return true;
            }
            return false;
        }

        public void RembourserPointsDeCompetence(int points)
        {
            pointsDeCompetencenRestant += points;
            OnPointsDeCompetenceChanged.Invoke(pointsDeCompetencenRestant);
        }

        public void CalculateTalentsPoints()
        {
            if (Vibrisse == 1)
            {
                pointsDeTalent = 2;
            }
            if (Vibrisse == 2)
            {
                pointsDeTalent = 4;
            }
            if (Vibrisse == 3)
            {
                pointsDeTalent = 8;
            }
            if (Vibrisse == 4)
            {
                pointsDeTalent = 16;
            }
            if (Vibrisse == 5)
            {
                pointsDeTalent = 24;
            }
            //pointsDeTalent = (2* Vibrisse + (Vibrisse - 1)) ;
            Debug.Log(Vibrisse + " aaaa " + pointsDeTalent);
            pointsDeTalentRestant=pointsDeTalent;
            OnPointsDeTalentChanged.Invoke(pointsDeTalentRestant);
        }

    }
}
