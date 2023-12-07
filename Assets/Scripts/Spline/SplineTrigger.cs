using Abstract.Collision;
using Car;
using Cinemachine;
using UnityEngine;

namespace Spline
{
    public class SplineTrigger : MonoBehaviour, ICollide
    {
        [SerializeField] private CinemachinePathBase _path;
        BoxCollider boxCollider;
        public CinemachinePathBase Path => _path;
        
        private void Awake()
        {
            boxCollider = GetComponent<BoxCollider>();
        }

        public void HandleCollide(CarController carController)
        {
            carController.CarFollowSpline(this);
        }

        public Vector3 ClosestPoint(Transform carTransform)
        {
            return boxCollider.bounds.ClosestPoint(carTransform.position);
        }
    }
}