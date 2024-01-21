using DG.Tweening;
using Snake3D.Runtime.Signals;
using TMPro;
using UnityEngine;

namespace Snake3D.Runtime.Controllers.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshPro scoreText;
        [SerializeField] private TextMeshPro highScoreText;
        [SerializeField] private TextMeshPro gameOverText;
        [SerializeField] private TextMeshPro pauseText;
        [SerializeField] private TextMeshPro startText;

        private int _score = 0;
        private int _highScore = 0;
        
        private bool _isGameOver;
        
        private void OnEnable()
        {
            PlayerSignals.Instance.OnCollectFood += OnCollectFood;
            GameSignals.Instance.OnGameOver += OnGameOver;
            GameSignals.Instance.OnGamePause += OnGamePause;
            GameSignals.Instance.OnGameResume += OnGameResume;
            GameSignals.Instance.OnGameRestart += OnGameRestart;
            GameSignals.Instance.OnGameStart += OnGameStart;
        }

        private void Start()
        {
            pauseText.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(false);
            startText.gameObject.SetActive(true);
            _isGameOver = false;
        }

        private void OnDisable()
        {
            PlayerSignals.Instance.OnCollectFood -= OnCollectFood;
            GameSignals.Instance.OnGameOver -= OnGameOver;
            GameSignals.Instance.OnGamePause -= OnGamePause;
            GameSignals.Instance.OnGameResume -= OnGameResume;
            GameSignals.Instance.OnGameRestart -= OnGameRestart;
            GameSignals.Instance.OnGameStart -= OnGameStart;
        }
        private void OnGameRestart()
        {
            gameOverText.gameObject.SetActive(false);
            startText.gameObject.SetActive(true);
            _isGameOver = false;
            _score = 0;
            scoreText.text = "SCORE:" + _score;
        }
        
        private void OnGameStart()
        {
            startText.gameObject.SetActive(false);
        }

        private void OnGameResume()
        {
            pauseText.gameObject.SetActive(false);
        }

        private void OnGamePause()
        {
            if (_isGameOver) return;
            pauseText.gameObject.SetActive(true);
        }

        private void OnGameOver()
        {
            gameOverText.gameObject.SetActive(true);
            _isGameOver = true;
        }

        private void OnCollectFood()
        {
            _score++;
            scoreText.text = "SCORE:" + _score;
            if (_score > _highScore)
            {
                _highScore = _score;
                highScoreText.text = "HIGH SCORE:" + _highScore;
            }

            scoreText.transform.DOScale(Vector3.one * 1.1f, 0.1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
        }
    }    
}


