using UnityEngine;

public class RotatingBehavior : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    private bool _isRotating = true;
    [SerializeField] private RotationDirection rotationDirection;

    private enum RotationDirection
    {
        Left,
        Right
    }

    void Update()
    {
        if (!_isRotating) return;
        switch (rotationDirection)
        {
            case RotationDirection.Right:
                transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
                break;
            case RotationDirection.Left:
                transform.Rotate(Vector3.down * (rotationSpeed * Time.deltaTime));
                break;
            default:
                transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
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
}