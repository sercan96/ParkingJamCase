using UnityEngine;

namespace Car
{
    [CreateAssetMenu(fileName = "CarData", menuName = "Car", order = 0)]
    public class CarSo : ScriptableObject
    {
        [Header("Car Movement")]
        public float moveSpeed;

        [Header("Car Backfire")] 
        public float moveDuration;
        public float moveDistance;
        public float rotateForce;
        public float rotateDuration;
        public int rotateVibrato;
        
        [Header("Car Input")]
        public float swipeThreshold;
        
        [Header("Car Spline Follow")]
        public float firstSplineMoveDuration;
        public float firstSplineRotateDuration;
        
        public float shakeRotateForce;
        public float shakeRotateDuration;
        public int shakeRotateVibrato;
        public float shakeRotateElasticity;
        
    }
}