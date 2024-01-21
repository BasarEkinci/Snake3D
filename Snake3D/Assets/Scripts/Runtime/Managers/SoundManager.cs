using System;
using Snake3D.Runtime.Signals;
using UnityEngine;

namespace Snake3D.Runtime.Managers
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip deathSound;
        [SerializeField] private AudioClip eatSound;

        private AudioSource _audioSource;

        private void OnEnable()
        {
            PlayerSignals.Instance.OnCollectFood += OnCollectFood;
            PlayerSignals.Instance.OnPlayerCrush += OnDeath;
        }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnDisable()
        {
            PlayerSignals.Instance.OnCollectFood -= OnCollectFood;
            PlayerSignals.Instance.OnPlayerCrush -= OnDeath;
        }

        private void OnDeath()
        {
            _audioSource.PlayOneShot(deathSound);
        }

        private void OnCollectFood()
        {
            _audioSource.PlayOneShot(eatSound);
        }
    }    
}

