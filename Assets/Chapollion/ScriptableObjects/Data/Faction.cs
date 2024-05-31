using System.Collections.Generic;
using UnityEngine;

namespace  Chapollion.ScriptableObjects.Data
{
   
    [CreateAssetMenu(fileName = "faction", menuName = "Nouvelle faction", order = 0)]
    public class Faction : NammedScriptableObject
    {
        [SerializeField][TextArea(3, 10)] public string Description;
        [SerializeField] private List<Chat> Chefs=new();
    }
}