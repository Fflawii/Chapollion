using UnityEngine;

namespace Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu]
    public class Talent : ScriptableObject
    {
        [SerializeField] private string nom;
        [SerializeField] private string description;
        [Range(0, 5)] [SerializeField] private int rang;
    }
}