using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EventOnScreenTap?.Invoke(Input.mousePosition);
        }
    }

    public static event Action<Vector3> EventOnScreenTap;
}