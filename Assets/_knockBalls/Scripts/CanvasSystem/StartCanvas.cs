using _knockBalls.Scripts.Level;
using TMPro;
using UnityEngine;

namespace _knockBalls.Scripts.CanvasSystem
{
    public class StartCanvas : CanvasController
    {
        [SerializeField] private TextMeshProUGUI _scoreText, _levelText;
        
        public override void Open()
        {
            base.Open();
            _levelText.text = LevelManager.Instance.LevelNumber.ToString();
        }

        public void StartGame()
        {
            LevelManager.Instance.StartGame();
        }
    }
}