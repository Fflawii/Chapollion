using UnityEngine;
namespace  Chapollion.ScriptableObjects.Data
{
  
  public abstract class Effet : ScriptableObject
    {
        public abstract void Apply(Chat aChat);
    }
   
}