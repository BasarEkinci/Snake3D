using Snake3D.Runtime.Signals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Snake3D.Runtime.Managers
{
    public class FoodManager : MonoBehaviour
    {
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
            transform.position = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
        }

        private void OnDisable()
        {
            PlayerSignals.Instance.OnCollectFood -= OnCollectFood;
        }

        private void OnCollectFood()
        {
            Vector3 newPosition = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
            transform.position = newPosition;
        }
    }
}