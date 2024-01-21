using Snake3D.Runtime.Signals;
using UnityEngine;

namespace Snake3D.Runtime.Managers
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip deathSound;
        [SerializeField] private AudioClip eatSound;

        private void OnEnable()
        {
            PlayerSignals.Instance.OnCollectFood += OnCollectFood;
            PlayerSignals.Instance.OnPlayerCrush += OnDeath;
        }

        private void OnDisable()
        {
            PlayerSignals.Instance.OnCollectFood -= OnCollectFood;
            PlayerSignals.Instance.OnPlayerCrush -= OnDeath;
        }

        private void OnDeath()
        {
            audioSource.PlayOneShot(deathSound);
        }

        private void OnCollectFood()
        {
            audioSource.PlayOneShot(eatSound);
        }
    }    
}

