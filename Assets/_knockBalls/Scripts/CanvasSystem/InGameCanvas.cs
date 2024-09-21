using _knockBalls.Scripts.Game;
using _knockBalls.Scripts.Level;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _knockBalls.Scripts.CanvasSystem
{
    public class InGameCanvas : CanvasController
    {
        [SerializeField] private TextMeshProUGUI _currentLevelText, _nextLevelText;
        [SerializeField] private Slider _slider;

        public override void Open()
        {
            base.Open();
            
            _currentLevelText.text = (LevelManager.Instance.LevelNumber + 1).ToString();
            _nextLevelText.text = (LevelManager.Instance.LevelNumber + 2).ToString();
            
            GameManager.Instance.gameIsStart = true;
            LevelManager.Instance.ChapterUpdate += ChapterSliderUpdate;
        }

        private void ChapterSliderUpdate()
        {
            var curChapter = LevelManager.Instance.currentChapter;
            _slider.value = (float)curChapter.chapterNum / curChapter.maxChapterInLevel;
        }
    }
}