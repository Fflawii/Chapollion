using UnityEngine;

namespace  Chapollion.ScriptableObjects.Data
{
    public abstract class NamedScriptableObject : ScriptableObject
    {
        [SerializeField] protected string nom;

        public void OnEnable()
        {
            nom = name;
        }
    }
}