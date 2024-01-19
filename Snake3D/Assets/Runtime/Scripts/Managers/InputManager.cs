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
        
        public float GetMovementInput()
        {
            float inputVector = _playerInputs.Player.Movement.ReadValue<float>();
            return inputVector;
        }
    }    
}

