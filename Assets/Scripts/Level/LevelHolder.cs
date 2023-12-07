using DG.Tweening;
using Managers;
using UnityEngine;

namespace Level
{
    public class LevelHolder : MonoBehaviour
    {
        public int totalCarCount;
        public int passCarCount;

        private void OnEnable()
        {
            EventManager.OnCollideCheckPointTrigger += IncreasePassCarCount;
        }

        private void OnDisable()
        {
            EventManager.OnCollideCheckPointTrigger -= IncreasePassCarCount;
        }

        private void IncreasePassCarCount()
        {
            passCarCount++;

            if (passCarCount >= totalCarCount)
            {
                DOVirtual.DelayedCall(1,() => EventManager.InvokeOnGameWin());
            }
        }
    }
}