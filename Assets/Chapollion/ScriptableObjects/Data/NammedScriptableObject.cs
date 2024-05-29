using UnityEngine;

namespace  Chapollion.ScriptableObjects.Data
{
    public abstract class NammedScriptableObject : ScriptableObject
    {
        [SerializeField] public string nom;
    }
}