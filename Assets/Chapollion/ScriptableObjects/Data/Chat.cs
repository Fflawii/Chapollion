using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace  Chapollion.ScriptableObjects.Data
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
        [SerializeField] private int reputation = 0;
        [SerializeField] private Faction faction;


        [SerializeField] private List<Qualite> qualites = new();
        [SerializeField] private List<Default> defauts = new();

        [SerializeField] private int pointsDeCreationRestant = 1;

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


        public int Griffre
        {
            get => griffre;
            set => griffre = value;
        }

        public int Poil
        {
            get => poil;
            set => poil = value;
        }

        public int Oeil
        {
            get => oeil;
            set => oeil = value;
        }

        public int Queue
        {
            get => queue;
            set => queue = value;
        }

        public int Caresse
        {
            get => caresse;
            set => caresse = value;
        }

        public int Ronronnement
        {
            get => ronronnement;
            set => ronronnement = value;
        }

        public int Coussinet
        {
            get => coussinet;
            set => coussinet = value;
        }

        public int Vibrisse
        {
            get => vibrisse;
            set => vibrisse = value;
        }
        public string Nom
        {
            get => nom;
            set 
            {
                if (nom ==  value) return;
                nom = value;
                OnCatNameChanged.Invoke(nom);
            }
        }



        public void Init(List<Competence> defaultCompetences, string aName, string aLignee, int pointsDeCreation)
        {
            nom = aName;
            pseudo = string.Empty;
            portrait = null;
            age = 7;
            race = null;
            lignee = aLignee;
            reputation = 0;
            faction = null;
            qualites = new List<Qualite>();
            defauts = new List<Default>();
            pointsDeCreationRestant = pointsDeCreation;
            Griffre = 1;
            Poil = 1;
            Oeil = 1;
            Queue = 1;

            Caresse = 1;
            Ronronnement = 1;
            Coussinet = 1;
            Vibrisse = 1;

            chance = 1;


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
                //competence.OnEnable();
                UnityEditor.AssetDatabase.AddObjectToAsset(competence, this);
                UnityEditor.EditorUtility.SetDirty(competence);
            }

            UnityEditor.EditorUtility.SetDirty(this);

            // Save all changes to disk
            // UnityEditor.AssetDatabase.SaveAssets();
#endif
            talents = new List<Talent>();
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
            }

            return 0;
        }
    }
}