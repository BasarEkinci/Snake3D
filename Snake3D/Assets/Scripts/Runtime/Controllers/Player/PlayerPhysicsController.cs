using Snake3D.Runtime.Signals;
using UnityEngine;

namespace Snake3D.Runtime.Controllers
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bait"))
            {
                PlayerSignals.Instance.OnCollectFood?.Invoke();
            }
            else if (other.CompareTag("Wall"))
            {
                PlayerSignals.Instance.OnPlayerCrush?.Invoke();
                Debug.Log("Player Crushed");
            }
        }
    }    
}

