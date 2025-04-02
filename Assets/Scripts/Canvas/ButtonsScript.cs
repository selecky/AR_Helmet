using EventManagers;
using UnityEngine;

namespace Canvas
{
    public class ButtonsScript : MonoBehaviour
    {
        void OnEnable()
        {
            PlanesEventManagerScript.EventOnPlanesDisabled += ShowButtons;
        }

        void OnDisable()
        {
            PlanesEventManagerScript.EventOnPlanesDisabled -= ShowButtons;
        }

        private void ShowButtons()
        {
            gameObject.SetActive(true);
        }
    }
}