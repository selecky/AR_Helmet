using System;
using UnityEngine;

namespace EventManagers
{
    public class HelmetEventManagerScript : MonoBehaviour
    {
        public static event Action
            EventOnHelmetInstantiated,
            EventOnHelmetDestroyed;

        public static void CallEventOnHelmetInstantiated() => EventOnHelmetInstantiated?.Invoke();
        public static void CallEventOnHelmetDestroyed() => EventOnHelmetDestroyed?.Invoke();
    }
}