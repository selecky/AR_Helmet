using System.Collections.Generic;
using EventManagers;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace PlaneScripts
{
    public class ScriptShowHelmet : MonoBehaviour
    {
        [SerializeField] private GameObject helmetPrefab;

        // [SerializeField] private GameObject effectPrefab;
        private List<ARRaycastHit> _hits;
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

        // Update is called once per frame
        void Update()
        {
            if (_planeManager.trackables.count > 0 && _planeManager.isActiveAndEnabled)
            {
                _planeManager.enabled = false;
            }
        }

        private void OnEnable()
        {
            CanvasEventManagerScript.EventOnScreenTap += ShowHelmet;
        }

        private void OnDisable()
        {
            CanvasEventManagerScript.EventOnScreenTap -= ShowHelmet;
        }

        void ShowHelmet(Vector3 vector3)
        {
            _hits = new List<ARRaycastHit>();

            bool colision =
                _raycastManager.Raycast(new Vector2(vector3.x, vector3.y), _hits, TrackableType.PlaneWithinPolygon);

            if (colision && !_isHelmetShown)
            {
                if (helmetPrefab != null)
                {
                    GameObject instantiatedHelmet = Instantiate(helmetPrefab);
                    instantiatedHelmet.transform.position = _hits[0].pose.position;
                    instantiatedHelmet.transform.rotation = _hits[0].pose.rotation;
                    instantiatedHelmet.SetActive(true);
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
            }
        }
    }
}