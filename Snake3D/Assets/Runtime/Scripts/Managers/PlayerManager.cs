using System;
using Runtime.Scripts.Controllers.Player;
using Snake3D.Runtime.Signals;
using UnityEngine;

namespace Snake3D.Runtime.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovementController movementController;


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
        
        }

        private void OnPlayerCrush()
        {
            Debug.Log("Player Crushed");
        }

        private void OnCollectFood()
        {
            Debug.Log("Food Collected");
        }
    }
}