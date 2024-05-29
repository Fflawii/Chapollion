using UnityEngine;

namespace Chapollion.ScriptableObjects.Data
{
    public abstract class NamedScriptableObject : ScriptableObject
    {
        [SerializeField] protected string nom;

        public string Nom
        {
            get => nom;
            set => nom = value;
        }

        public void OnEnable()
        {
            Nom = name;
        }
    }
}