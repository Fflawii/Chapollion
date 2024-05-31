using UnityEngine;

namespace  Chapollion.ScriptableObjects.Data
{
    public abstract class NammedScriptableObject : ScriptableObject
    {
        [SerializeField] public string nom;

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