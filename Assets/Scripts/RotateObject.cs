using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private enum Direction { Left, Right, Stop }
    private Direction _direction = Direction.Stop;
    private GameObject _objectToRotate;

    [SerializeField]
    private float rotationSpeed = 100.0f;

    public void RotateLeft() => _direction = Direction.Left;
    public void RotateRight() => _direction = Direction.Right;
    public void RotateStop() => _direction = Direction.Stop;


    private void Update()
    {
        _objectToRotate = FindAnyObjectByType<TagHelmet>()?.gameObject;

        if (_objectToRotate == null) return;

        Vector3 rotation = _direction switch
        {
            Direction.Left => Vector3.down,
            Direction.Right => Vector3.up,
            _ => Vector3.zero
        };

        _objectToRotate.transform.Rotate(rotation * (rotationSpeed * Time.deltaTime));
    }
}