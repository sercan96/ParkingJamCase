using System;
using DG.Tweening;
using Managers;
using Sounds;
using UnityEngine;

namespace CheckPoint
{
    public class CheckPointController : MonoBehaviour
    {
        [SerializeField] private Transform pivotTransform;

        private void OnEnable()
        {
            EventManager.OnCollideCheckPointTrigger += OpenCheckPoint;
        }

        private void OnDisable()
        {
            EventManager.OnCollideCheckPointTrigger -= OpenCheckPoint;
        }

        private void OpenCheckPoint()
        {
            AudioManager.Instance.PlaySound(SoundName.CheckPoint);
            pivotTransform.DORotateQuaternion(Quaternion.Euler(0, 0, -90), .5f).OnComplete(CloseCheckPoint);
        }

        private void CloseCheckPoint()
        {
            pivotTransform.DORotateQuaternion(Quaternion.Euler(0, 0, 0), .5f).SetDelay(0.2f);
        }
    }
}