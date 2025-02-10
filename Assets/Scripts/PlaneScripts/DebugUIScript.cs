using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DebugUIScript : MonoBehaviour
{
    private List<ARRaycastHit> hits;
    private ARRaycastManager raycastManager;
    private ARSessionOrigin sessionOrigin;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.EventOnScreenTap += ShowClickedPosition;
        sessionOrigin = FindObjectOfType<ARSessionOrigin>();
        raycastManager = sessionOrigin.GetComponent<ARRaycastManager>();
    }

    private void OnDisable()
    {
        EventManager.EventOnScreenTap -= ShowClickedPosition;
    }

    void ShowClickedPosition(Vector3 vector3)
    {
        hits = new List<ARRaycastHit>();
        Text debugText = GetComponent<Text>();

        bool colision =
            raycastManager.Raycast(new Vector2(vector3.x, vector3.y), hits, TrackableType.PlaneWithinPolygon);

        StringBuilder sb = new StringBuilder();
        sb.Append("x: ");
        sb.Append(vector3.x);
        sb.Append(", y: ");
        sb.Append(vector3.y);
        sb.Append(", C: ");
        sb.Append(colision);
        string textToDisplay = sb.ToString();

        debugText.text = textToDisplay;
    }
}