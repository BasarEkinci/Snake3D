using Snake3D.Runtime.Signals;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Snake3D.Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        private PlayerInputs _playerInputs;
        private bool _isGamePaused;
        private bool _isGameStarted = false;

        private void Awake()
        {
            _playerInputs = new PlayerInputs();
            _playerInputs.Game.Enable();
            _playerInputs.Game.PlayPause.performed += OnPauseGame;
            _playerInputs.Game.Restart.performed += OnRestartGame;
            _playerInputs.Game.Start.performed += OnStartGame;
        }

        private void OnStartGame(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && !_isGameStarted)
            {
                GameSignals.Instance.OnGameStart?.Invoke();
                _isGameStarted = true;
            }
        }

        private void OnRestartGame(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                GameSignals.Instance.OnGameRestart?.Invoke();
                Debug.Log("Game Restarted");
            }
        }

        private void Start()
        {
            _isGamePaused = false;
        }

        private void OnPauseGame(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                if (_isGamePaused)
                {
                    Debug.Log("Game Resumed");
                    GameSignals.Instance.OnGameResume?.Invoke();
                    _isGamePaused = false;
                }
                else
                {
                    Debug.Log("Game Paused");
                    GameSignals.Instance.OnGamePause?.Invoke();
                    _isGamePaused = true;
                }
            }
        }
    }
}