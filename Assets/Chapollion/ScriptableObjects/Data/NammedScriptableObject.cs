using UnityEngine;

namespace  Chapollion.ScriptableObjects.Data
{
    public abstract class NammedScriptableObject : ScriptableObject
    {
        [SerializeField] protected string nom;
    }
}