using System.Collections.Generic;
using UnityEngine;

namespace  Chapollion.ScriptableObjects.Data
{
   
    [CreateAssetMenu(fileName = "faction", menuName = "Nouvelle faction", order = 0)]
    public class Faction : NamedScriptableObject
    {
        [SerializeField][TextArea(3, 10)] private string Description;
        [SerializeField] private List<Chat> Chefs=new();
    }
}