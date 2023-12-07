using System;
using Car;
using UnityEngine;

namespace Managers
{
    public class CarManager : MonoBehaviour
    {
        public static CarManager Instance;

        public CarController currentSwipeCar;

        private void Awake()
        {
            Instance = this;
        }
    }
}