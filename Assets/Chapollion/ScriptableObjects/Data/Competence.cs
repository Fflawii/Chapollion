using UnityEngine;
namespace  Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName="Competence")]

 public class Competence:ScriptableObject
    {
        [SerializeField] private string nom;
        [SerializeField][TextArea(3, 15)] private string description;
        [Range(0,5)] [SerializeField] private int babase;
        [Range(0,5)] [SerializeField] private int rang;
    }

}