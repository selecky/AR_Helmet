using System;
using UnityEngine;

namespace EventManagers
{
    public class PlanesEventManagerScript : MonoBehaviour
    {
        public static event Action
            EventOnPlanesVisible,
            EventOnPlanesDisabled;

        public static void CallEventOnPlanesVisible() => EventOnPlanesVisible?.Invoke();
        public static void CallEventOnPlanesDisabled() => EventOnPlanesDisabled?.Invoke();
    }
}