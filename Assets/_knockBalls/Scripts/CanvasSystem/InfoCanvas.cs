using _knockBalls.Scripts.Data;
using _knockBalls.Scripts.Game;
using _knockBalls.Scripts.Level;
using _knockBalls.Scripts.Score;
using _knockBalls.Scripts.Sound;
using TMPro;
using UnityEngine;
using AudioType = _knockBalls.Scripts.Data.AudioType;

namespace _knockBalls.Scripts.CanvasSystem
{
    public class InfoCanvas : CanvasController
    {
        [SerializeField] private TextMeshProUGUI _scoreText, _levelText, _highScoreText;
        [SerializeField] private ParticleSystem _openParticle;
        
        public override void Open()
        {
            base.Open();
            
            GameManager.Instance.gameIsStart = false;
            
            if (_openParticle)
                _openParticle.Play();
            
            _levelText.text = (LevelManager.Instance.LevelNumber + 1).ToString();

            var scoreManager = ScoreManager.Instance;
            if (_scoreText)
                _scoreText.text = scoreManager.GetScore.ToString();
            if (_highScoreText)
                _highScoreText.text = scoreManager.GetHighScore.ToString();
            
            switch (canvasType)
            {
                case CanvasType.LevelFail:
                    SoundManager.Instance.PlayEffect(AudioType.LevelFail);
                    break;
                case CanvasType.LevelSuccess:
                    SoundManager.Instance.PlayEffect(AudioType.LevelSuccess);
                    break;
            }
            
            scoreManager.ResetScore();
        }

        public void StartGame()
        {
            LevelManager.Instance.StartGame();
            CanvasManager.Open(CanvasType.InGame);
        }
    }
}