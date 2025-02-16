using System;
using UnityEngine;

namespace EventManagers
{
    public class CanvasEventManagerScript : MonoBehaviour
    {
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
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CallEventOnScreenTap(Input.mousePosition);
            }
        }
    }
}