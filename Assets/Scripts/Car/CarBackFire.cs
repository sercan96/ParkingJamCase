using System;
using DG.Tweening;
using Managers;
using UnityEngine;

namespace Car
{
    public class CarBackFire
    {
        private CarController _carController;

        public CarBackFire(CarController carController)
        {
            _carController = carController;
        }
        
        public void BackFire(Transform obstacle)
        {
            var direction =  obstacle.position - _carController.transform.position;
            var dot = Vector3.Dot(_carController.transform.forward.normalized , direction.normalized);
            
            var moveDireciton = _carController.transform.forward * MathF.Sign(-dot);

            
            _carController.transform.DOLocalMove(_carController.transform.localPosition + moveDireciton * _carController.carSo.moveDistance, 
                _carController.carSo.moveDuration).OnComplete((() =>
            {
                _carController.isSwipe = false;
                CarManager.Instance.currentSwipeCar = null;
            }));
            
            _carController.transform.DOPunchRotation(direction * _carController.carSo.rotateForce, _carController.carSo.rotateDuration, 
                _carController.carSo.rotateVibrato);
        }
    }
}