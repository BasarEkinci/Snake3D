using System;
using Runtime.Scripts.Controllers.Player;
using Snake3D.Runtime.Controllers;
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

        private void OnEnable()
        {
            PlayerSignals.Instance.OnCollectFood += OnCollectFood;
            PlayerSignals.Instance.OnPlayerCrush += OnPlayerCrush;
        }

        private void Start()
        {
            tailController.Grow(tailPrefab);
        }

        private void OnDisable()
        {
            PlayerSignals.Instance.OnCollectFood -= OnCollectFood;
            PlayerSignals.Instance.OnPlayerCrush -= OnPlayerCrush;
        }

        private void Update()
        {
            if(moveSpeed <= 0) return;
            movementController.HandlePlayerRotate(rotateSpeed);
            movementController.HandlePlayerMove(moveSpeed);
            tailController.SetTailPosition();
        }

        private void OnPlayerCrush()
        {
            moveSpeed = 0;
            tailController.Shrink();
        }

        private void OnCollectFood()
        {
            tailController.Grow(tailPrefab);
        }
    }
}