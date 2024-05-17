using UnityEngine;

namespace  Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName="Race")]

 public class Race:ScriptableObject
    {
        [SerializeField] private string nom;
    }

}