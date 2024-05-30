using Chapollion.ScriptableObjects.Data;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace Chapollion.UI
{
    public class CatExposeBehavior : MonoBehaviour
    {
        [SerializeField] private Chat myCat;
        [SerializeField] private Library myLib;

        [SerializeField] private UnityEvent<string> onCatNameChanged = new();
        [SerializeField] private UnityEvent<string> onCatLigneeChanged = new();
        [SerializeField] private UnityEvent<string> onPointsDeCreationRestantChanged = new();
        [SerializeField] private UnityEvent<string> onPointsDeCompetencesChanged = new();

        [SerializeField] private TMP_Text pointsDeCompetenceRestantText; // Assurez-vous d'avoir une référence à ce texte

        private void OnEnable()
        {
            onCatNameChanged.Invoke(myCat.Nom);
            onCatLigneeChanged.Invoke(myCat.Lignee);
            onPointsDeCreationRestantChanged.Invoke(myCat.PointsDeCreationRestant.ToString());
            onPointsDeCompetencesChanged.Invoke(myCat.pointsDeCompetencenRestant.ToString());

            myCat.OnCatNameChanged.AddListener(CatNameChanged);
            myCat.OnCatLigneeChanged.AddListener(CatLigneeChanged);
            myCat.OnPointsDeCreationRestantChanged.AddListener(PointsDeCreationChanged);
            myCat.OnPointsDeCompetenceChanged.AddListener(PointsDeCompetencesChanged);
        }

        private void PointsDeCompetencesChanged(int pointsRestants)
        {
            onPointsDeCompetencesChanged.Invoke(pointsRestants.ToString());
            pointsDeCompetenceRestantText.text = pointsRestants.ToString();
        }

        private void PointsDeCreationChanged(int pointsRestants)
        {
            onPointsDeCreationRestantChanged.Invoke(pointsRestants.ToString());
        }

        private void CatLigneeChanged(string aLignee)
        {
            onCatLigneeChanged.Invoke(aLignee);
        }
        public void GenerateLignee()
        {
            myCat.Lignee = myLib.GenerateLignee();
        }
        public void GenerateName()
        {
            myCat.Nom = myLib.GenerateName();
        }
        private void CatNameChanged(string aCatName)
        {
            onCatNameChanged.Invoke(aCatName);
        }

        private void OnDisable()
        {
            myCat.OnCatNameChanged.RemoveListener(CatNameChanged);
            myCat.OnCatLigneeChanged.RemoveListener(CatLigneeChanged);
            myCat.OnPointsDeCreationRestantChanged.RemoveListener(PointsDeCreationChanged);
        }
    }
}
