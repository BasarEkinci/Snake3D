using Snake3D.Runtime.Signals;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Snake3D.Runtime.Managers
{
    public class GameManager : MonoBehaviour
    {
        private PlayerInputs _playerInputs;
        private bool _isGamePaused;
        private bool _isGameStarted;
        private bool _isGameOver;

        private void Awake()
        {
            _playerInputs = new PlayerInputs();
            _playerInputs.Game.Enable();
            _playerInputs.Game.PlayPause.performed += OnPauseGame;
            _playerInputs.Game.Restart.performed += OnRestartGame;
            _playerInputs.Game.Start.performed += OnStartGame;
        }

        private void OnEnable()
        {
            GameSignals.Instance.OnGameOver += OnGameOver;
        }
        
        private void Start()
        {
            _isGamePaused = false;
            _isGameStarted = false;
        }

        private void OnDisable()
        {
            GameSignals.Instance.OnGameOver -= OnGameOver;
        }
        
        private void OnStartGame(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && !_isGameStarted && !_isGameOver)
            {
                GameSignals.Instance.OnGameStart?.Invoke();
                _isGameStarted = true;
            }
        }

        private void OnRestartGame(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton() && _isGameOver)
            {
                GameSignals.Instance.OnGameRestart?.Invoke();
                _isGameOver = false;
            }
            
        }
        
        private void OnPauseGame(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                if(!_isGameStarted) return;
                if (_isGamePaused)
                {
                    GameSignals.Instance.OnGameResume?.Invoke();
                    _isGamePaused = false;
                }
                else
                {
                    GameSignals.Instance.OnGamePause?.Invoke();
                    _isGamePaused = true;
                }
            }
        }
        
        private void OnGameOver()
        {
            _isGameStarted = false;
            _isGameOver = true;
        }
    }
}