using Runtime.Scripts.Extentions;
using UnityEngine.Events;

namespace Snake3D.Runtime.Signals
{
    public class PlayerSignals : MonoSingelton<PlayerSignals>
    {
        public UnityAction OnCollectFood = delegate {  };
        public UnityAction OnPlayerCrush = delegate {  };
    }    
}

