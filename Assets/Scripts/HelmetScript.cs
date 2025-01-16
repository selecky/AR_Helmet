using EventManagers;
using UnityEngine;

public class HelmetScript : MonoBehaviour
{
    private RotationBehavior _rotationBehavior;

    private void Awake()
    {
        _rotationBehavior = gameObject.GetComponent<RotationBehavior>();
    }

    private void OnEnable()
    {
        CanvasEventManagerScript.EventButtonLeftPointerDown += RotateLeft;
        CanvasEventManagerScript.EventButtonLeftPointerUp += StopRotation;
        CanvasEventManagerScript.EventButtonRightPointerDown += RotateRight;
        CanvasEventManagerScript.EventButtonRightPointerUp += StopRotation;
    }

    private void OnDisable()
    {
        CanvasEventManagerScript.EventButtonLeftPointerDown -= RotateLeft;
        CanvasEventManagerScript.EventButtonLeftPointerUp -= StopRotation;
        CanvasEventManagerScript.EventButtonRightPointerDown -= RotateRight;
        CanvasEventManagerScript.EventButtonRightPointerUp -= StopRotation;
    }

    private void RotateLeft()
    {
        _rotationBehavior.ChangeRotationDirection(rotationDirection: RotationBehavior.RotationDirection.Left);
        _rotationBehavior.StartRotation();
    }

    private void RotateRight()
    {
        _rotationBehavior.ChangeRotationDirection(rotationDirection: RotationBehavior.RotationDirection.Right);
        _rotationBehavior.StartRotation();
    }

    private void StopRotation()
    {
        _rotationBehavior.StopRotation();
    }
}