using Spline;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public static class EventManager
    {
        
        public static event UnityAction OnCollideCheckPointTrigger;

        public static void InvokeOnCollideCheckPointTrigger()
        {
            OnCollideCheckPointTrigger?.Invoke();
        }
        
        public static event UnityAction OnGameWin;

        public static void InvokeOnGameWin()
        {
            OnGameWin?.Invoke();
        }

    }
}