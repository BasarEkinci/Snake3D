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
            throw new NotImplementedException();
        }

        private void OnCollectFood()
        {
            throw new NotImplementedException();
        }
    }
}