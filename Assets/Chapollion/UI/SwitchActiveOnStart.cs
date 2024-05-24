using UnityEngine;

namespace Koboct.UI
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