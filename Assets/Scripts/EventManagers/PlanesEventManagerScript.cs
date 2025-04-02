using System;
using UnityEngine;

namespace EventManagers
{
    public class PlanesEventManagerScript : MonoBehaviour
    {
        public static event Action
            EventOnPlanesVisible;

        public static void CallEventOnPlanesVisible() => EventOnPlanesVisible?.Invoke();
    }
}