using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Chapollion.ScriptableObjects.Data

{
public class CatExposeBehavior : MonoBehaviour
  
    {
     [SerializeField] private Chat myCat;
     [SerializeField] private UnityEvent<string> CatNameChanged=new();
    } 
}