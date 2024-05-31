using UnityEngine;

namespace Chapollion.ScriptableObjects.Data
{
    public abstract class NamedScriptableObject : ScriptableObject
    {
        [SerializeField] private string nom;

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