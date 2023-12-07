using UnityEngine;

namespace Sounds
{
    [System.Serializable]
    public class Sound
    {
        public SoundName soundName;
        public AudioSource audioSource;
        public AudioClip clip;
   
    }
    public enum SoundName
    {
        Win,
        CheckPoint,
        ObstacleCrash,
        CarCrash,
        Movement
    }
}