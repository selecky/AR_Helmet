using EventManagers;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.XR.ARFoundation;

namespace Canvas
{
    public class InfoWindowScript : MonoBehaviour
    {
        [SerializeField] private XROrigin xrOrigin;
        private bool _arePlanesVisible;
        private TextMeshProUGUI _infoText;
        private ARPlaneManager _planeManager;

        // Start is called before the first frame update
        void Awake()
        {
            _infoText = GetComponentInChildren<TextMeshProUGUI>();
            _planeManager = xrOrigin.GetComponent<ARPlaneManager>();
        }

        private void Update()
        {
            if (_planeManager.trackables.count > 0 && !_arePlanesVisible)
            {
                _arePlanesVisible = true;
                PlanesEventManagerScript.CallEventOnPlanesVisible();
            }
        }

        private void OnEnable()
        {
            var stringToUse = LocalizationSettings.StringDatabase.GetLocalizedString("move_camera");
            _infoText.text = stringToUse;

            PlanesEventManagerScript.EventOnPlanesVisible += ShowTextOnPlanesVisible;
            PlanesEventManagerScript.EventOnPlanesDisabled += DisableInfoWindow;
        }

        private void OnDisable()
        {
            PlanesEventManagerScript.EventOnPlanesVisible -= ShowTextOnPlanesVisible;
            PlanesEventManagerScript.EventOnPlanesDisabled -= DisableInfoWindow;
        }

        void ShowTextOnPlanesVisible()
        {
            string stringToUse = LocalizationSettings.StringDatabase.GetLocalizedString("tap_plane");
            _infoText.text = stringToUse;
        }

        void DisableInfoWindow()
        {
            gameObject.SetActive(false);
        }
    }
}