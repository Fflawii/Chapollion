using UnityEngine;

namespace Chapollion.UI
{
    public class SwitchActiveOnStart : MonoBehaviour
    {
        public bool DoActivate;

        private void Start()
        {
            gameObject.SetActive(DoActivate);
        }
    }
}