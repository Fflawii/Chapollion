using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace  Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName="Race")]
    public class Race:NammedScriptableObject
    {
         public Sprite ImageRace;
        
        public List<Default> DefautsObligatoires = new();
        public List<Qualite> QualitésObligatoires = new();
    }
}