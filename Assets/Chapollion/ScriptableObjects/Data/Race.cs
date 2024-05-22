using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace  Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName="Race")]
    public class Race:NammedScriptableObject
    {
        [SerializeField] private Sprite ImageRace;
        
        [SerializeField] private List<Default> DefautsObligatoires = new();
        [SerializeField] private List<Qualite> QualitésObligatoires = new();
    }
}