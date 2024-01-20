using System;
using Snake3D.Runtime.Signals;
using TMPro;
using UnityEngine;

namespace Snake3D.Runtime.Controllers
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshPro scoreText;

        private int score = 0;
        
        private void OnEnable()
        {
            PlayerSignals.Instance.OnCollectFood += OnCollectFood;
        }

        private void OnDisable()
        {
            PlayerSignals.Instance.OnCollectFood -= OnCollectFood;
        }

        private void OnCollectFood()
        {
            score++;
            scoreText.text = "SCORE\n" + score;
        }
    }    
}


