using System.Collections.Generic;

using UnityEngine;


namespace  Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName="Race")]
    public class Race:NammedScriptableObject
    {
        [SerializeField] public Sprite ImageRace;
        
        Animator animator;
        [SerializeField] public RuntimeAnimatorController MaJolieAnim;

        [SerializeField] public List<Default> DefautsObligatoires = new();
        [SerializeField] public List<Qualite> QualitésObligatoires = new();

 
    }
}