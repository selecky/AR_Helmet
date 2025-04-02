using System.Collections.Generic;
using EventManagers;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace PlaneScripts
{
    public class ShowHelmetOnPlaneTapScript : MonoBehaviour
    {
        [SerializeField] private GameObject helmetPrefab;
        [SerializeField] private ARSession arSession;

        private readonly List<ARRaycastHit> _hits = new();

        // [SerializeField] private GameObject effectPrefab;
        private GameObject _instantiatedHelmet;
        bool _isHelmetShown;
        private ARPlaneManager _planeManager;
        private ARRaycastManager _raycastManager;
        private XROrigin _xrOrigin;

        void Start()
        {
            _xrOrigin = FindFirstObjectByType<XROrigin>();
            _raycastManager = _xrOrigin.GetComponent<ARRaycastManager>();
            _planeManager = _xrOrigin.GetComponent<ARPlaneManager>();
            _isHelmetShown = false;
        }

        private void OnEnable()
        {
            CanvasEventManagerScript.EventOnScreenTap += ShowHelmet;
            CanvasEventManagerScript.EventButtonResetClick += ResetHelmet;
        }

        private void OnDisable()
        {
            CanvasEventManagerScript.EventOnScreenTap -= ShowHelmet;
            CanvasEventManagerScript.EventButtonResetClick -= ResetHelmet;
        }

        void ShowHelmet(Vector2 tapPosition)
        {
            _hits.Clear();

            bool colision =
                _raycastManager.Raycast(tapPosition, _hits, TrackableType.PlaneWithinPolygon);

            if (colision && !_isHelmetShown)
            {
                if (helmetPrefab)
                {
                    _instantiatedHelmet = Instantiate(helmetPrefab);
                    _instantiatedHelmet.transform.position = _hits[0].pose.position;
                    _instantiatedHelmet.transform.rotation = _hits[0].pose.rotation;
                    _instantiatedHelmet.SetActive(true);
                }

                // if (effectPrefab != null)
                // {
                //     GameObject instantiatedEffect = Instantiate(effectPrefab);
                //     instantiatedEffect.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                //     instantiatedEffect.transform.position = _hits[0].pose.position;
                //     instantiatedEffect.transform.rotation = _hits[0].pose.rotation;
                //     instantiatedEffect.SetActive(true);
                //     AudioSource audioSource = instantiatedEffect.GetComponentInChildren<AudioSource>();
                //     if (audioSource != null)
                //     {
                //         if (!audioSource.isPlaying)
                //         {
                //             audioSource.Play(); // Start playing the audio
                //         }
                //     }
                // }


                _planeManager.SetTrackablesActive(false);
                _planeManager.enabled = false;
                _isHelmetShown = true;
                HelmetEventManagerScript.CallEventOnHelmetInstantiated();
            }
        }

        private void ResetHelmet()
        {
            if (_instantiatedHelmet)
            {
                Destroy(_instantiatedHelmet);
                _instantiatedHelmet = null;
            }

            arSession.Reset(); // removing all planes from ARPlaneManager 
            _planeManager.enabled = true;
            _isHelmetShown = false;
            HelmetEventManagerScript.CallEventOnHelmetDestroyed();
        }
    }
}