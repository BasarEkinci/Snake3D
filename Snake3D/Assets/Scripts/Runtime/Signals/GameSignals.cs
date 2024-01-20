using Runtime.Scripts.Extentions;
using UnityEngine.Events;

namespace Snake3D.Runtime.Signals
{
    public class GameSignals : MonoSingelton<GameSignals>
    {
        public UnityAction OnGameStart = delegate {  };
        public UnityAction OnGameRestart = delegate {  };
        public UnityAction OnGamePause = delegate {  };
        public UnityAction OnGameResume = delegate {  };
        public UnityAction OnGameOver = delegate {  };
    }
}