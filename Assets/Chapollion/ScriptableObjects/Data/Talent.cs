using UnityEngine;

namespace Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName="Talent")]
    public class Talent : NamedScriptableObject
    {
        [SerializeField][TextArea(3, 15)] private string description;
        [Range(0, 5)] [SerializeField] public int rang;
    }
}