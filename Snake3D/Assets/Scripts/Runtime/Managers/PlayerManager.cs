using Runtime.Scripts.Controllers.Player;
using Snake3D.Runtime.Controllers;
using Snake3D.Runtime.Controllers.Player;
using Snake3D.Runtime.Signals;
using UnityEngine;

namespace Snake3D.Runtime.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private GameObject tailPrefab;
        [Header("Controllers")]
        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerTailController tailController;
        
        [Header("Movement Values")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotateSpeed;
        
        private Vector3 _playerStartPosition;
        private bool _isGameOver;
        private bool _canMove = true;

        private void OnEnable()
        {
            PlayerSignals.Instance.OnCollectFood += OnCollectFood;
            PlayerSignals.Instance.OnPlayerCrush += OnPlayerCrush;
            GameSignals.Instance.OnGameRestart += OnGameRestart;
            GameSignals.Instance.OnGamePause += OnGamePause;
            GameSignals.Instance.OnGameResume += OnGameResume;
            GameSignals.Instance.OnGameStart += OnGameStart;
        }

        private void Start()
        {
            _playerStartPosition = new Vector3(0,1f,0);
            _canMove = false;
        }

        private void OnDisable()
        {
            PlayerSignals.Instance.OnCollectFood -= OnCollectFood;
            PlayerSignals.Instance.OnPlayerCrush -= OnPlayerCrush;
            GameSignals.Instance.OnGameRestart -= OnGameRestart;
            GameSignals.Instance.OnGamePause -= OnGamePause;
            GameSignals.Instance.OnGameResume -= OnGameResume;
            GameSignals.Instance.OnGameStart -= OnGameStart;
        }
        private void Update()
        {
            if(_isGameOver || !_canMove) return;
            movementController.HandlePlayerRotate(rotateSpeed);
            movementController.HandlePlayerMove(moveSpeed);
            tailController.SetTailPosition();
        }

        private void OnPlayerCrush()
        {
            _isGameOver = true;
            GameSignals.Instance.OnGameOver?.Invoke();
            tailController.Shrink();
        }

        private void OnCollectFood()
        {
            tailController.Grow(tailPrefab);
        }
        private void OnGameStart()
        {
            _canMove = true;
        }
        private void OnGameRestart()
        {
            if(!_isGameOver) return;
            transform.position = _playerStartPosition;
            _isGameOver = false;
            _canMove = false;
        }
        
        private void OnGameResume()
        {
            _canMove = true;
        }
        private void OnGamePause()
        {
            _canMove = false;
        }
    }
}