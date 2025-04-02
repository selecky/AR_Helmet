using EventManagers;
using UnityEngine;

namespace Canvas
{
    public class ButtonsScript : MonoBehaviour
    {
        void Awake()
        {
            HelmetEventManagerScript.EventOnHelmetInstantiated += ShowButtons;
            HelmetEventManagerScript.EventOnHelmetDestroyed += HideButtons;
            gameObject.SetActive(false);
        }

        void OnDestroy()
        {
            HelmetEventManagerScript.EventOnHelmetInstantiated -= ShowButtons;
            HelmetEventManagerScript.EventOnHelmetDestroyed -= HideButtons;
        }

        private void HideButtons()
        {
            gameObject.SetActive(false);
        }

        private void ShowButtons()
        {
            gameObject.SetActive(true);
        }
    }
}