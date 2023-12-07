using Abstract.Collision;
using Car;
using Managers;
using UnityEngine;

namespace CheckPoint
{
    public class CheckPointTrigger : MonoBehaviour, ICollide
    {
        public void HandleCollide(CarController carController)
        {
            EventManager.InvokeOnCollideCheckPointTrigger();
            carController.DestroyCar();
        }
    }
}