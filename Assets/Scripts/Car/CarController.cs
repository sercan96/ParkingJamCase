using Abstract.Collision;
using Cinemachine;
using DG.Tweening;
using Lean.Touch;
using Managers;
using Sounds;
using Spline;
using UnityEngine;

namespace Car
{
    public class CarController : MonoBehaviour, ICollide
    {
        public CarSo carSo;
        
        private CarMovement _carMovement;
        private CarBackFire _carBackFire;
        private CarSplineFollow _carSplineFollow;
        private CarInput _carInput;
        
        public bool isMove;
        public bool isSwipe;
        public bool isActive;
        private bool _isSplineFollow;

        private Camera _camera;
        
        [SerializeField] private CinemachineDollyCart cinemachineDollyCart;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private GameObject smokeTrailParticle;

        private void Awake()
        {
            _camera = Camera.main;
            _carMovement = new CarMovement(this);
            _carBackFire = new CarBackFire(this);
            _carSplineFollow = new CarSplineFollow(this, cinemachineDollyCart);
            _carInput = new CarInput(this, _camera, layerMask);
        }

        private void Update()
        {
            _carInput.TouchControl();

            if (isMove)
            {
                _carMovement.MoveStraight();
            }
        }

        public void MoveStart(Vector3 direction)
        {
            _carMovement.SetMoveDirection(direction);
            isMove = true;
            AudioManager.Instance.PlaySound(SoundName.Movement);
        }

        public void MoveStop()
        {
            isMove = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICollide collide))
            {
                collide.HandleCollide(this);
            }
        }

        public void CarBackFire(Transform obstacle)
        {
            if(!isActive) return;
            DOVirtual.DelayedCall(0.2f, () => isActive = false);
            _carBackFire.BackFire(obstacle);
        }

        public void CarFollowSpline(SplineTrigger splineTrigger)
        {
            if(_isSplineFollow) return;
            _isSplineFollow = true;
            _carSplineFollow.FollowSpline(splineTrigger);
            smokeTrailParticle.SetActive(true);
        }

        public void DestroyCar()
        {
            Destroy(gameObject, 1);
        }

        public void HandleCollide(CarController carController)
        {
            if(isActive) return;
            carController.MoveStop();
            carController.CarBackFire(transform);
            ShakeObstacle();
            AudioManager.Instance.PlaySound(SoundName.CarCrash);
        }

        private void ShakeObstacle()
        {
            transform.DOKill(true);
            transform.DOPunchRotation(Vector3.back * carSo.shakeRotateForce, carSo.shakeRotateDuration, carSo.shakeRotateVibrato, carSo.shakeRotateElasticity);
        }
    }
}
