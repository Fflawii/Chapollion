using UnityEngine;
namespace  Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName="Race")]

 public class Competence:ScriptableObject
    {
        [SerializeField] private string nom;
        [Range(0,5)] [SerializeField] private int babase;
        [Range(0,5)] [SerializeField] private int rang;
    }

}