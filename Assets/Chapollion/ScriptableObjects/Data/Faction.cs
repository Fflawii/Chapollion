using System.Collections.Generic;
using UnityEngine;

namespace  Chapollion.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "faction", menuName = "Nouvelle faction", order = 0)]
 public class Faction :ScriptableObject
    {
        [SerializeField] private string Description;
        [SerializeField] private List<Chat> Chafs=new();
    }

}