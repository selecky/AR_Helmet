using EventManagers;
using UnityEngine;

namespace Canvas
{
    public class ButtonsScript : MonoBehaviour
    {
        void Awake()
        {
            PlanesEventManagerScript.EventOnPlanesDisabled += ShowButtons;
            gameObject.SetActive(false);
        }

        void OnDestroy()
        {
            PlanesEventManagerScript.EventOnPlanesDisabled -= ShowButtons;
        }

        private void ShowButtons()
        {
            gameObject.SetActive(true);
        }
    }
}