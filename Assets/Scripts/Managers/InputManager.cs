using System;
using Car;
using Lean.Touch;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;
        
        private float delta;
        private float timer;
        
        private LeanFinger myFinger;
        public LeanFinger Finger => myFinger;
        private bool fingerActive => myFinger != null;
        
        private void Awake()
        {
            Instance = this;
        }
        

        private void OnEnable()
        {
            LeanTouch.OnFingerDown += FingerDown;
            LeanTouch.OnFingerUp += FingerUp;
        }

        private void OnDisable()
        {
            LeanTouch.OnFingerDown -= FingerDown;
            LeanTouch.OnFingerUp -= FingerUp;
        }
    

        public Vector2 GetSwipeScreenDelta()
        {
            if (!fingerActive)
                return Vector2.zero;
            
            return myFinger.SwipeScreenDelta;
        }


        private void FingerDown(LeanFinger finger)
        {
            if (myFinger == null)
            {
                myFinger = finger;
            }
        }
        

        private void FingerUp(LeanFinger finger)
        {
            if (myFinger == finger)
            {
                myFinger = null;
            }
        }
    }
}