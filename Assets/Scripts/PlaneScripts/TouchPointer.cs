using UnityEngine;

public class TouchPointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.EventOnScreenTap += MoveOnClick;
    }

    private void OnDisable()
    {
        EventManager.EventOnScreenTap -= MoveOnClick;
    }

    void MoveOnClick(Vector3 vector3)
    {
        Vector3 clickedPosition =
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f));
        transform.position = clickedPosition;
    }
}