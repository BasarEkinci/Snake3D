using System;
using Runtime.Scripts.Controllers.Player;
using Snake3D.Runtime.Controllers;
using Snake3D.Runtime.Signals;
using UnityEngine;

namespace Snake3D.Runtime.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerTailController tailController;


        private void OnEnable()
        {
            PlayerSignals.Instance.OnCollectFood += OnCollectFood;
            PlayerSignals.Instance.OnPlayerCrush += OnPlayerCrush;
        
        }
        private void OnDisable()
        {
            PlayerSignals.Instance.OnCollectFood -= OnCollectFood;
            PlayerSignals.Instance.OnPlayerCrush -= OnPlayerCrush;
        }

        private void Update()
        {
            movementController.HandlePlayerRotate();
            movementController.HandlePlayerMove();
            tailController.SetTailPosition();
        }

        private void OnPlayerCrush()
        {
            Debug.Log("Player Crushed");
        }

        private void OnCollectFood()
        {
            tailController.Grow();
        }
    }
}