using System.Collections.Generic;
using UnityEngine;

namespace  Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "Chat", menuName = "Create Cat", order = 0)]
    public class Chat : ScriptableObject
    {
        [SerializeField] private string nom;
        [SerializeField] private string pseudo;

        [SerializeField] private Sprite portrait;

        [Range(1, 30)] [SerializeField] private int age;
        [SerializeField] private Race race;
        [SerializeField] private string lignee;
        [SerializeField] private int reputation = 0;
        [SerializeField] private string faction;

        [SerializeField] private List<Qualite> qualites = new();
        [SerializeField] private List<Default> defauts = new();

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

        public void Init(List<Competence> defaultCompetences, string aName, string aLignee)
        {
            nom = aName;
            pseudo = string.Empty;
            portrait = null;
            age = 7;
            race = null;
            lignee = aLignee;
            reputation = 0;
            faction = string.Empty;
            qualites = new List<Qualite>();
            defauts = new List<Default>();

            griffre = 1;
            poil = 1;
            oeil = 1;
            queue = 1;

            caresse = 1;
            ronronnement = 1;
            coussinet = 1;
            vibrisse = 1;

            chance = 1;


#if UNITY_EDITOR
            foreach (var competence in competences)
            {
                UnityEditor.AssetDatabase.RemoveObjectFromAsset(competence);
            }
#endif

            competences = defaultCompetences;
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(this);
            foreach (var competence in competences)
            {
                competence.name = competence.name.Replace("(Clone)", string.Empty);
               // competence.OnEnable();
                UnityEditor.AssetDatabase.AddObjectToAsset(competence, this);
                UnityEditor.EditorUtility.SetDirty(competence);
             
            }

            // Save all changes to disk
           // UnityEditor.AssetDatabase.SaveAssets();
#endif
            talents = new List<Talent>();
        }
    }
}