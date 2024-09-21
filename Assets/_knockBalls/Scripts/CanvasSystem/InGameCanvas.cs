using _knockBalls.Scripts.Game;
using _knockBalls.Scripts.Level;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _knockBalls.Scripts.CanvasSystem
{
    public class InGameCanvas : CanvasController
    {
        public static InGameCanvas Instance { get; private set; } 
        
        [SerializeField] private TextMeshProUGUI _currentLevelText, _nextLevelText, _bulletCountText;
        [SerializeField] private Slider _slider;

        private void Awake()
        {
            Instance ??= this;
        }
        
        public override void Open()
        {
            base.Open();
            
            UpdateBulletCountTxt();
            _currentLevelText.text = (LevelManager.Instance.LevelNumber + 1).ToString();
            _nextLevelText.text = (LevelManager.Instance.LevelNumber + 2).ToString();
            
            GameManager.Instance.gameIsStart = true;
            LevelManager.Instance.ChapterUpdate += ChapterSliderUpdate;
        }

        public void UpdateBulletCountTxt() => _bulletCountText.text = "x" + LevelManager.Instance.currentChapter.RemainingNumberCount; 
        
        private void ChapterSliderUpdate()
        {
            var curChapter = LevelManager.Instance.currentChapter;
            _slider.value = (float)curChapter.chapterNum / curChapter.maxChapterInLevel;
        }
    }
}