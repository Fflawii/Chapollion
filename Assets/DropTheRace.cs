
using UnityEngine;
using Chapollion.ScriptableObjects.Data;
using TMPro;
using System.Runtime.InteropServices;
using static TMPro.TMP_Dropdown;
using System.Collections.Generic;
using System;


public class DropTheRace : MonoBehaviour
{
    public Library MyLibrary;
    public TMP_Dropdown dropdown;
    public Chat MonChat;

    public Animator animator;

    public List<string> listrace = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        dropdown.ClearOptions();
        listrace = new List<string>();
        foreach (var item in MyLibrary.racesDispo)
        {
            listrace.Add(item.Nom);
        }
        dropdown.AddOptions(listrace);
        dropdown.onValueChanged.AddListener(OnValueChanged);
        OnValueChanged(0);
    }

    private void OnValueChanged(int arg0)
    {
        animator.runtimeAnimatorController = MyLibrary.racesDispo[arg0].MaJolieAnim;
        MonChat.Race = MyLibrary.racesDispo[arg0];
    }
}
