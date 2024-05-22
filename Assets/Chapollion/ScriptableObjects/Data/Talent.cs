using UnityEngine;

namespace Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName="Talent")]
    public class Talent : ScriptableObject
    {
        [SerializeField] private string nom;
        [SerializeField][TextArea(3, 15)] private string description;
        [Range(0, 5)] [SerializeField] private int rang;
    }
}