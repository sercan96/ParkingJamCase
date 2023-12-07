using UnityEngine;

namespace Car
{
    public class CarMovement
    {
        private CarController _carController;
        private float _speed;
        private Vector3 _moveDirection;

        public CarMovement(CarController carController)
        {
            _carController = carController;
            _speed = carController.carSo.moveSpeed;
        }
        
        public void SetMoveDirection(Vector3 swipeDirection)
        {
            var forward = _carController.transform.TransformDirection(Vector3.forward);
            var dot = Vector3.Dot(forward.normalized, swipeDirection.normalized);

            if (dot < 0)
            {
                _moveDirection = -_carController.transform.forward;
            }
            else
            {
                _moveDirection = _carController.transform.forward;

            }
        }
        
        public void MoveStraight()
        {
            _carController.transform.position += _moveDirection * (Time.deltaTime * _speed);
        }
        
    }
}