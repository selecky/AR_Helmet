using System;
using UnityEngine;

public class CanvasEventManager : MonoBehaviour
{
    public static event Action ButtonLeftTapEvent, ButtonRightTapEvent, ButtonHornsTapEvent;

    public static void CallButtonLeftTapEvent() => ButtonLeftTapEvent?.Invoke();
    public static void CallButtonRightTapEvent() => ButtonRightTapEvent?.Invoke();
    public static void CallButtonHornsTapEvent() => ButtonHornsTapEvent?.Invoke();
}
