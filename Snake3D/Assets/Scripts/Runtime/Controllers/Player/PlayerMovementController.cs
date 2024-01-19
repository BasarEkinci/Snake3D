using Snake3D.Runtime.Managers;
using UnityEngine;

namespace Runtime.Scripts.Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;

        [Header("Movement Settings")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotateSpeed;

        private float _inputDirection;
        float _moveDirection;
        public void HandlePlayerRotate()
        {
            _inputDirection = inputManager.GetMovementInput();
            _moveDirection = _inputDirection;
            transform.Rotate(Vector3.up * (_moveDirection * rotateSpeed * Time.deltaTime));
        }
        
        public void HandlePlayerMove()
        {
            transform.position += transform.forward * (moveSpeed * Time.deltaTime);
        }
    }
}