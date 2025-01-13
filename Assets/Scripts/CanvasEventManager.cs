using System;
using UnityEngine;

public class CanvasEventManager : MonoBehaviour
{
    public static event Action
        EventButtonLeftPointerDown,
        EventButtonLeftPointerUp,
        EventButtonRightPointerDown,
        EventButtonRightPointerUp,
        EventButtonHornsClick;

    public static void CallEventButtonLeftPointerDown() => EventButtonLeftPointerDown?.Invoke();
    public static void CallEventButtonLeftPointerUp() => EventButtonLeftPointerUp?.Invoke();
    public static void CallEventButtonRightPointerDown() => EventButtonRightPointerDown?.Invoke();
    public static void CallEventButtonRightPointerUp() => EventButtonRightPointerUp?.Invoke();
    public static void CallEventButtonHornsClick() => EventButtonHornsClick?.Invoke();
}