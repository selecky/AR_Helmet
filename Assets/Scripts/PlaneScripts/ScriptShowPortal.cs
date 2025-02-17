using System.Collections.Generic;
using EventManagers;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ScriptShowPortal : MonoBehaviour
{
    [SerializeField] private GameObject portalPrefab;
    [SerializeField] private GameObject effectPrefab;
    private List<ARRaycastHit> hits;
    bool isPortalShown;
    private ARPlaneManager planeManager;
    private ARRaycastManager raycastManager;
    private ARSessionOrigin sessionOrigin;

    // Start is called before the first frame update
    void Start()
    {
        CanvasEventManagerScript.EventOnScreenTap += ShowPortal;
        sessionOrigin = FindObjectOfType<ARSessionOrigin>();
        raycastManager = sessionOrigin.GetComponent<ARRaycastManager>();
        planeManager = sessionOrigin.GetComponent<ARPlaneManager>();
        isPortalShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (planeManager.trackables.count > 0 && planeManager.isActiveAndEnabled)
        {
            planeManager.enabled = false;
        }
    }

    private void OnDisable()
    {
        CanvasEventManagerScript.EventOnScreenTap -= ShowPortal;
    }

    void ShowPortal(Vector3 vector3)
    {
        hits = new List<ARRaycastHit>();

        bool colision =
            raycastManager.Raycast(new Vector2(vector3.x, vector3.y), hits, TrackableType.PlaneWithinPolygon);

        if (colision && !isPortalShown)
        {
            if (portalPrefab != null)
            {
                GameObject instantiatedPortal = Instantiate(portalPrefab);
                instantiatedPortal.transform.position = hits[0].pose.position;
                instantiatedPortal.transform.rotation = hits[0].pose.rotation;
                instantiatedPortal.SetActive(true);
                print("9999999999999999999999999999999999999999");
                print(instantiatedPortal.active);
            }

            if (effectPrefab != null)
            {
                GameObject instantiatedEffect = Instantiate(effectPrefab);
                instantiatedEffect.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                instantiatedEffect.transform.position = hits[0].pose.position;
                instantiatedEffect.transform.rotation = hits[0].pose.rotation;
                instantiatedEffect.SetActive(true);

                print("9999999999999999999999999999999999999999");
                print(instantiatedEffect.active);

                AudioSource audioSource = instantiatedEffect.GetComponentInChildren<AudioSource>();
                if (audioSource != null)
                {
                    print("11111111111111111111111111111111111111111111111111111111111");
                    print(audioSource.isPlaying);
                    if (!audioSource.isPlaying)
                    {
                        audioSource.Play(); // Start playing the audio
                        print("222222222222222222222222222222222222222222222222222222");
                        print(audioSource.isPlaying);
                    }
                }
            }


            planeManager.SetTrackablesActive(false);
            planeManager.enabled = false;
            isPortalShown = true;
        }
    }
}