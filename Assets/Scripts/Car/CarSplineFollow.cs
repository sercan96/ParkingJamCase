using Cinemachine;
using DG.Tweening;
using Managers;
using Spline;
using UnityEngine;

namespace Car
{
    public class CarSplineFollow
    {
        private CarController _carController;
        private CinemachineDollyCart _dollyCart;

        public CarSplineFollow(CarController carController, CinemachineDollyCart dollyCart)
        {
            _carController = carController;
            _dollyCart = dollyCart;
        }
        
        public void FollowSpline(SplineTrigger splineTrigger)
        {
            Vector3 point = splineTrigger.ClosestPoint(_carController.transform);

            var path = splineTrigger.Path;
            _dollyCart.m_Path = path;

            var closestPoint = path.FindClosestPoint(point, 0, -1, 10);
            closestPoint = path.FromPathNativeUnits(closestPoint, _dollyCart.m_PositionUnits);

            var startPosition = path.EvaluatePositionAtUnit(closestPoint, _dollyCart.m_PositionUnits);
            var startRotation = path.EvaluateOrientationAtUnit(closestPoint, _dollyCart.m_PositionUnits);

            _carController.transform.DOMove(startPosition, _carController.carSo.firstSplineMoveDuration);

            _carController.transform.DORotateQuaternion(startRotation, _carController.carSo.firstSplineRotateDuration)
                .OnComplete(() =>
                {
                    _dollyCart.m_Position = closestPoint;
                    _dollyCart.enabled = true;

                    DOVirtual.Float(_dollyCart.m_Speed / 3f, _dollyCart.m_Speed, 0.2f, value => _dollyCart.m_Speed = value);
                    
                    CarManager.Instance.currentSwipeCar = null;
                }); 
        }
    }
}