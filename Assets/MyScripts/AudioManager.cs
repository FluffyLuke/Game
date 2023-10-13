using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class AudioManager : MonoBehaviour
    {
        // backing field for actually store the Singleton instance
        public static AudioManager Instance;
        [SerializeField] private AudioSource _musicSource, _effectsSource;
        [SerializeField] private AudioClip music;
        private void Awake()
        {
            _musicSource.loop = true;
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
                PlaySoundOnRepeat(music);
            } else { Destroy(gameObject);}
        }

        public void PlaySound(AudioClip clip)
        {
            _effectsSource.PlayOneShot(clip);
        }
        public void PlaySoundOnRepeat(AudioClip clip)
        {
            _musicSource.clip = clip;
            _musicSource.Play();
        }
    }

    public class PlaySoundOnStart : MonoBehaviour
    {
        [SerializeField] private AudioClip _clip;

        private void Start()
        {
            AudioManager.Instance.PlaySound(_clip);
        }
    }
}