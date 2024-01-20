using UnityEngine;
using UnityEngine.InputSystem;

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
        
        // ReSharper disable Unity.PerformanceAnalysis
        public float GetMovementInput()
        {
            float inputVector = _playerInputs.Player.Movement.ReadValue<float>();
            return inputVector;
        }
        
    }    
}

