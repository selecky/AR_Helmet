using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EventManagers
{
    public class CanvasEventManagerScript : MonoBehaviour
    {
        private void Update()
        {
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                // The new Input System stores the position in a Vector2, convert it to Vector3 if needed.
                print("00000000000000000000000000000000000000000000000000000000");
            }


            // Check if a touchscreen is available.
            if (Touchscreen.current == null) return;
            // Iterate over all active touches.
            if (Touchscreen.current.touches.Count > 0)
            {
                print("111111111111111111111111111111111111111111111111111111");
            }

            ;


            // foreach (var touch in Touchscreen.current.touches)
            // {
            //     // When the touch is first pressed down.
            //     if (touch.press.wasPressedThisFrame)
            //     {
            //         // Convert the touch position (Vector2) to Vector3 if needed.
            //         CallEventOnScreenTap(touch.position.ReadValue());
            //     }
            // }
        }

        public static event Action
            EventButtonLeftPointerDown,
            EventButtonLeftPointerUp,
            EventButtonRightPointerDown,
            EventButtonRightPointerUp,
            EventButtonHornsClick;

        public static event Action<Vector3> EventOnScreenTap;

        public static void CallEventButtonLeftPointerDown() => EventButtonLeftPointerDown?.Invoke();
        public static void CallEventButtonLeftPointerUp() => EventButtonLeftPointerUp?.Invoke();
        public static void CallEventButtonRightPointerUp() => EventButtonRightPointerUp?.Invoke();
        public static void CallEventButtonRightPointerDown() => EventButtonRightPointerDown?.Invoke();
        public static void CallEventButtonHornsClick() => EventButtonHornsClick?.Invoke();
        private static void CallEventOnScreenTap(Vector3 position) => EventOnScreenTap?.Invoke(position);
    }
}