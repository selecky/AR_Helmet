using UnityEngine;

public class ToggleVisibilityBehavior : MonoBehaviour
{
    public enum RotationDirection
    {
        Left,
        Right
    }

    private RotationDirection _rotationDirection;

    void Update()
    {
        if (!_isRotating) return;
        switch (_rotationDirection)
        {
            case RotationDirection.Right:
                enabled == true;
                transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
                break;
            case RotationDirection.Left:
                transform.Rotate(Vector3.down * (RotationSpeed * Time.deltaTime));
                break;
            default:
                transform.Rotate(Vector3.zero * (RotationSpeed * Time.deltaTime));
                break;
        }
    }

    public void StartRotation()
    {
        _isRotating = true;
    }

    public void StopRotation()
    {
        _isRotating = false;
    }

    public void ChangeRotationDirection(RotationDirection rotationDirection)
    {
        _rotationDirection = rotationDirection;
    }
}