using System;
using Snake3D.Runtime.Managers;
using UnityEngine;

namespace Runtime.Scripts.Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;


        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotateSpeed;

        private void Update()
        {
            HandlePlayerRotate();
            HandlePlayerMove();
        }

        private void HandlePlayerRotate()
        {
            float inputDirection = inputManager.GetMovementInput();
            float moveDirection = inputDirection;
            transform.Rotate(Vector3.up * (moveDirection * rotateSpeed * Time.deltaTime));
        }
        
        private void HandlePlayerMove()
        {
            transform.position += transform.forward * (moveSpeed * Time.deltaTime);
        }
    }
}