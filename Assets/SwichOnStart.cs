using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichOnStart : MonoBehaviour
{
    public bool DoActivate;
        private void Start()
    {
        gameObject.SetActive(DoActivate);
    }
}
