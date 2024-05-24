using System;
using System.Linq;
using Koboct.ScriptableObjects.Data;
using TMPro;
using UnityEngine;

namespace Koboct.UI
{
    public class RaceDropdownBehavior : MonoBehaviour
    {
        public Library Library;

        public TMP_Dropdown Dropdown;

        public Chat MonChat;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void OnEnable()
        {
            PointsCharacChanged(MonChat.PointsDeCreationRestant);
            MonChat.OnPointsDeCreationRestantChanged.AddListener(PointsCharacChanged);
            Dropdown.options.Clear();
            foreach (var race in Library.RacesDispo)
            {
                Dropdown.options.Add(new TMP_Dropdown.OptionData(race.Nom, race.ImageRace, Color.white));
            }
         
            Dropdown.onValueChanged.AddListener(RaceChanged);
            Dropdown.value=0;
        }

        private void RaceChanged(int arg0)
        {
            var i = Library.RacesDispo.First(r => r.Nom == Dropdown.options[arg0].text);
            MonChat.Race = i;
        }

        private void OnDisable()
        {
            MonChat.OnPointsDeCreationRestantChanged.RemoveListener(PointsCharacChanged);
            Dropdown.onValueChanged.RemoveListener(RaceChanged);
        }

        private void PointsCharacChanged(int arg0)
        {
            Dropdown.interactable = arg0 == 0;
            Dropdown.value = 0;
        }
    }
}