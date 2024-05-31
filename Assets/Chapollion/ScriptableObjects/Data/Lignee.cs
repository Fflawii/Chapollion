using System;
using System.Collections.Generic;
using UnityEngine;

namespace  Chapollion.ScriptableObjects.Data
{ 
    [CreateAssetMenu(fileName="Lignee")]
    public class Lignee: NamedScriptableObject
    {
        public List<LigneeSuffix> Suffixes=new ();

    }

    [Serializable]
    public class LigneeSuffix
    {
        public string Nom;
        public bool Invert;
    }
}