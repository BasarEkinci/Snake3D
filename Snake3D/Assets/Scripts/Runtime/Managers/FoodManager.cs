using DG.Tweening;
using Snake3D.Runtime.Signals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Snake3D.Runtime.Managers
{
    public class FoodManager : MonoBehaviour
    {
        [SerializeField] ParticleSystem collectParticle;
        [SerializeField] private float minX;
        [SerializeField] private float maxX;
        [SerializeField] private float minZ;
        [SerializeField] private float maxZ;
        
        private void OnEnable()
        {
            PlayerSignals.Instance.OnCollectFood += OnCollectFood;
        }

        private void Start()
        {
            transform.DOMoveY(transform.position.y + 0.5f,0.5f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
            transform.position = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
        }

        private void OnDisable()
        {
            PlayerSignals.Instance.OnCollectFood -= OnCollectFood;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Tail"))
                SetPosition();
        }

        private void OnCollectFood()
        {
            Instantiate(collectParticle, transform.position, Quaternion.identity);
            SetPosition();
        }
        
        private void SetPosition()
        {
            Vector3 newPosition = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
            transform.position = newPosition;
        }
    }
}