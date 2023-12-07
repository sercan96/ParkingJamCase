using Lean.Touch;
using Managers;
using UnityEngine;

namespace Car
{
    public class CarInput
    {
        private CarController _carController;
        
        private Camera _camera;
        private LayerMask _carMask;
        private float _threshold;
        
        public CarInput(CarController carController, Camera camera, LayerMask layerMask)
        {
            _carController = carController;
            _camera = camera;
            _carMask = layerMask;
            _threshold = carController.carSo.swipeThreshold;
        }
        

        public void TouchControl()
        {
            if(InputManager.Instance.Finger == null || CarManager.Instance.currentSwipeCar != null) return;
            
            var ray = _camera.ScreenPointToRay(InputManager.Instance.Finger.ScreenPosition);
            
            var isHit = Physics.Raycast(ray, out var hitInfo, 1000, _carMask.value);

            if (!isHit)
            {
                return;
            }

            if (!hitInfo.transform.TryGetComponent<CarController>(out var carController))
            {
                return;
            }
            
            if (InputManager.Instance.GetSwipeScreenDelta().magnitude > _threshold && !carController.isSwipe)
            {
                CarManager.Instance.currentSwipeCar = carController;
                carController.isSwipe = true;
                if(carController.isMove) return;
            
                var delta = InputManager.Instance.Finger.ScreenDelta.normalized;
                var convertedDirection = new Vector3(delta.x, 0, delta.y);
                carController.isActive = true;
                carController.MoveStart(convertedDirection);
            }
        }
        
    }
}