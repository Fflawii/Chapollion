using UnityEngine;
using System.Collections.Generic;


namespace  Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName="Game Library", menuName="Create Game Library", order=0)]

 public class Library:ScriptableObject
    {
        [SerializeField]private List<string> prefixNomDispo=new();
        [SerializeField]private List<string> sufixNomDispo=new();
        [SerializeField]private List<string> prefixLigneeDispo=new();
        [SerializeField]private List<string> sufixLigneeDispo=new();
        [SerializeField]private List<string> factionsDispo=new();

        [SerializeField]private List<Qualite> qualitesDispo=new();
        [SerializeField]private List<Default> defaultsDispo=new();

        [SerializeField]private List<Competence> competenceDispo=new();
        [SerializeField]private List<Talent> talentDispo=new();

    public List<Competence> GetDefaultCompetencesCopy()
    {
        var default = new List<Competence>();
        foreach (var competence in competencesDispo)
        {
            default.add(Instantiate(competence));
        }

    }

    }

}