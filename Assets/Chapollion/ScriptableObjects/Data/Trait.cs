using UnityEngine;

namespace  Chapollion.ScriptableObjects.Data
{public abstract class Trait: NammedScriptableObject
    {
        [Range(-8,4)] public int gainPerte;
        
        [SerializeField] private Effet effet;
    }
}