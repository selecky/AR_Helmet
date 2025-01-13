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

        public static void CallEventButtonLeftPointerDown() => EventButtonLeftPointerDown?.Invoke();
        public static void CallEventButtonLeftPointerUp() => EventButtonLeftPointerUp?.Invoke();
        public static void CallEventButtonRightPointerUp() => EventButtonRightPointerUp?.Invoke();
        public static void CallEventButtonRightPointerDown() => EventButtonRightPointerDown?.Invoke();
        public static void CallEventButtonHornsClick() => EventButtonHornsClick?.Invoke();
    }
}