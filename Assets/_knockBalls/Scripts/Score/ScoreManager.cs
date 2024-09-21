using _knockBalls.Scripts.CanvasSystem;
using UnityEngine;

namespace _knockBalls.Scripts.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        public int GetHighScore
        {
            get => PlayerPrefs.GetInt("highScore", 0);
            set => PlayerPrefs.SetInt("highScore", _score > GetHighScore ? _score : GetHighScore);
        }

        public int GetScore => _score;
        
        private int _score;

        private void Awake()
        {
            Instance ??= this;
        }

        public void IncreaseScore(int num)
        {
            _score += num;
            InGameCanvas.Instance.UpdateScoreText(_score.ToString());
            InGameCanvas.Instance.CreateFloatingText($"+{num}");
        }

        public void ResetScore()
        {
            _score = 0;   
        }

        public void FinishLevel()
        {
            GetHighScore = _score;
        }
    }
}