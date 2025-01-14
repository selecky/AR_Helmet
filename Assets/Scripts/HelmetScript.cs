using UnityEngine;

public class HelmetScript : MonoBehaviour
{
    private RotationBehavior _rotationBehavior;

    private void Awake()
    {
        _rotationBehavior = gameObject.AddComponent<RotationBehavior>();
        CanvasEventManager.EventButtonLeftPointerDown += RotateLeft;
        CanvasEventManager.EventButtonLeftPointerUp += StopRotation;
        CanvasEventManager.EventButtonRightPointerDown += RotateRight;
        CanvasEventManager.EventButtonRightPointerUp += StopRotation;
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