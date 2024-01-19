using UnityEngine;

namespace Snake3D.Runtime.Managers
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInputs _playerInputs;
        
        private void Awake()
        {
            _playerInputs = new PlayerInputs();
            _playerInputs.Player.Enable();
        }
        
        public Vector2 GetMovementInput()
        {
            Vector2 inputVector = _playerInputs.Player.Movement.ReadValue<Vector2>();
            inputVector = inputVector.normalized;
            return inputVector;
        }
    }    
}

