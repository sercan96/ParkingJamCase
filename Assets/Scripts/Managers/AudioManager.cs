using System;
using Sounds;
using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        public Sound[] musicSounds;
        public AudioSource[] audioSources;
    
        private void Awake()
        {
            Instance = this;
        }
        

        public void PlaySound(SoundName soundName)
        {
            Sound s = Array.Find(musicSounds, x => x.soundName == soundName);
        
            if (s == null)
            {
                Debug.Log("Sound Not Found");
            }
            else
            {
                AudioSource audioSource = s.audioSource;
            
                audioSource.clip = s.clip;
                audioSource.Play();
            }
        }

    }
}