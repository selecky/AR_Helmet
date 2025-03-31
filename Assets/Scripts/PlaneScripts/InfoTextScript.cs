using System.Collections.Generic;
using EventManagers;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class InfoTextScript : MonoBehaviour
{
    private ARPlaneManager _planeManager;
    private XROrigin _xrOrigin;
    private List<ARRaycastHit> hits;
    private ARRaycastManager raycastManager;
    private ARSessionOrigin sessionOrigin;

    // Start is called before the first frame update
    void Start()
    {
        PlanesEventManagerScript.EventOnPlanesVisible += ShowTextOnPlanesVisible;
        sessionOrigin = FindObjectOfType<ARSessionOrigin>();
        raycastManager = sessionOrigin.GetComponent<ARRaycastManager>();
        _planeManager = _xrOrigin.GetComponent<ARPlaneManager>();
    }

    private void OnEnable()
    {
        PlanesEventManagerScript.EventOnPlanesVisible += ShowTextOnPlanesVisible;
    }

    private void OnDisable()
    {
        PlanesEventManagerScript.EventOnPlanesVisible -= ShowTextOnPlanesVisible;
    }

    void ShowTextOnPlanesVisible()
    {
        var tableEntry = LocalizationSettings.StringDatabase.GetTableEntry(dialogueLocalizedRef.TableReference,
            dialogueLocalizedRef.TableEntryReference);
        var key = tableEntry.Entry.SharedEntry.Key;


        Text infoText = GetComponent<Text>();
        infoText.text = textToDisplay;
    }
}