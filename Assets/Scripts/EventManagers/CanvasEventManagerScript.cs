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
                CallEventOnScreenTap(Mouse.current.position.ReadValue());
            }

            if (Touchscreen.current != null)
            {
                foreach (var touch in Touchscreen.current.touches)
                {
                    if (touch.press.wasPressedThisFrame)
                    {
                        CallEventOnScreenTap(touch.position.ReadValue());
                    }
                }
            }
        }

        public static event Action
            EventButtonLeftPointerDown,
            EventButtonLeftPointerUp,
            EventButtonRightPointerDown,
            EventButtonRightPointerUp,
            EventButtonHornsClick;

        public static event Action<Vector2> EventOnScreenTap;

        public static void CallEventButtonLeftPointerDown() => EventButtonLeftPointerDown?.Invoke();
        public static void CallEventButtonLeftPointerUp() => EventButtonLeftPointerUp?.Invoke();
        public static void CallEventButtonRightPointerUp() => EventButtonRightPointerUp?.Invoke();
        public static void CallEventButtonRightPointerDown() => EventButtonRightPointerDown?.Invoke();
        public static void CallEventButtonHornsClick() => EventButtonHornsClick?.Invoke();
        private static void CallEventOnScreenTap(Vector2 position) => EventOnScreenTap?.Invoke(position);
    }
}