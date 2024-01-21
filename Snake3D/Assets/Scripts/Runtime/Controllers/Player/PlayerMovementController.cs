using Snake3D.Runtime.Managers;
using UnityEngine;

namespace Snake3D.Runtime.Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;

        private float _inputDirection;
        private float _moveDirection;
        public void HandlePlayerRotate(float rotateSpeed)
        {
            _inputDirection = inputManager.GetMovementInput();
            _moveDirection = _inputDirection;
            transform.Rotate(Vector3.up * (_moveDirection * rotateSpeed * Time.deltaTime));
        }
        
        public void HandlePlayerMove(float moveSpeed)
        {
            transform.position += transform.forward * (moveSpeed * Time.deltaTime);
        }
    }
}