using System;
using Unity.VisualScripting;
using UnityEngine;

public class HelmetScript : MonoBehaviour
{
    private RotationBehavior _rotationBehavior;

    private void Awake()
    {
        _rotationBehavior = gameObject.AddComponent<RotationBehavior>();
    }

    private void OnEnable()
    {
        CanvasEventManager.EventButtonLeftPointerDown += RotateLeft;
        CanvasEventManager.EventButtonLeftPointerUp += StopRotation;
        CanvasEventManager.EventButtonRightPointerDown += RotateRight;
        CanvasEventManager.EventButtonRightPointerUp += StopRotation;
    }

    private void OnDisable()
    {
        CanvasEventManager.EventButtonLeftPointerDown -= RotateLeft;
        CanvasEventManager.EventButtonLeftPointerUp -= StopRotation;
        CanvasEventManager.EventButtonRightPointerDown -= RotateRight;
        CanvasEventManager.EventButtonRightPointerUp -= StopRotation;
    }

    private void RotateLeft()
    {
        _rotationBehavior.StartRotation();
        _rotationBehavior.ChangeRotationDirection(rotationDirection: RotationBehavior.RotationDirection.Left);
    }

    private void RotateRight()
    {
        _rotationBehavior.StartRotation();
        _rotationBehavior.ChangeRotationDirection(rotationDirection: RotationBehavior.RotationDirection.Right);
    }

    private void StopRotation()
    {
        _rotationBehavior.StopRotation();
    }
}