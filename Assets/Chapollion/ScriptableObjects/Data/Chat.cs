using UnityEngine;
using System.Collections.Generic;


namespace  Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName="Chat", menuName = "Data/Create Cat", order =0)]
    public class Chat :  ScriptableObject
    {
        [SerializeField] private string nom;
        [SerializeField] private string pseudo;

        [SerializeField] private Sprite portait;

        [Range(1,30)][SerializeField] private int age;
        [SerializeField] private Race race;
        [SerializeField] private string lignee;
        [SerializeField] private int reputation=0;
        [SerializeField] private string faction;

        [SerializeField] private List<Qualite> qualites=new();
        [SerializeField] private List<Default> defaults=new();


        [Header("Physique")]
        [Range(1,5)][SerializeField] private int griffe=1; 
        [Range(1,5)][SerializeField] private int poil=1; 
        [Range(1,5)][SerializeField] private int oeil=1; 
        [Range(1,5)][SerializeField] private int queue=1; 

        [Header("Mental")]
        [Range(1,5)][SerializeField] private int caresse=1; 
        [Range(1,5)][SerializeField] private int ronronnement=1; 
        [Range(1,5)][SerializeField] private int cousinet=1; 
        [Range(1,5)][SerializeField] private int vibrisse=1; 

        [Header("Chance")]
        [Range(1,5)][SerializeField] private int chance=1; 

        [Header("Compétence")]
        [SerializeField] private List<Competence> competence = new();

         [Header("Talent")]
        [SerializeField] private List<Talent> talent = new();


        public void Init(List<Competence)
        {
            nom=string.Empty;
            pseudo = string.Empty;
            portait= null;
            age =7;
            race = null;
            lignee =string.Empty;
            reputation=0;
            faction = string.Empty;
            qualites = new List<Qualite>;
            defaults = new List<Default>;

            griffe = 1;
            poil = 1;
            oeil = 1;
            queue = 1;

            caresse = 1;
            ronronnement = 1;
            cousinet = 1;
            vibrisse = 1;

            
            talent = new List<Talent>;
            competence = new List<Competence>;


        }


     }

   



}
