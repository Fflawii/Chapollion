using UnityEngine;
namespace  Chapollion.ScriptableObjects.Data
{
     public abstract class Trait: NamedScriptableObject
    {
        [SerializeField][Range(-8,4)] private int gainPerte;
        
        [SerializeField] private Effet effet;
    }
}