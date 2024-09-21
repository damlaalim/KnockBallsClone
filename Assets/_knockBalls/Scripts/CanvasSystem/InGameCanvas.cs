using System.Collections;
using _knockBalls.Scripts.Game;
using _knockBalls.Scripts.Level;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _knockBalls.Scripts.CanvasSystem
{
    public class InGameCanvas : CanvasController
    {
        public static InGameCanvas Instance { get; private set; }

        public float maskMaxScale; 

        [SerializeField] private Transform _maskImage;
        [SerializeField] private TextMeshProUGUI _currentLevelText, _nextLevelText, _bulletCountText, _levelEndTimeText;
        [SerializeField] private Slider _slider;
        
        private void Awake()
        {
            Instance ??= this;
        }
        
        public override void Open()
        {
            base.Open();
            
            UpdateBulletCountTxt();
            ShowLevelTimeText(false); 
            UpdateMaskImageScale(maskMaxScale * Vector3.one);
            
            _currentLevelText.text = (LevelManager.Instance.LevelNumber + 1).ToString();
            _nextLevelText.text = (LevelManager.Instance.LevelNumber + 2).ToString();
            
            GameManager.Instance.gameIsStart = true;
            LevelManager.Instance.ChapterUpdate += ChapterSliderUpdate;
        }

        public void UpdateBulletCountTxt() => _bulletCountText.text = "x" + LevelManager.Instance.currentChapter.RemainingNumberCount; 
        
        public void UpdateLevelTimeText(string text) => _levelEndTimeText.text = text;
        
        public void ShowLevelTimeText(bool show) => _levelEndTimeText.enabled = show;
        public void UpdateMaskImageScale(Vector3 scale) => _maskImage.localScale = scale;
        private void ChapterSliderUpdate()
        {
            var curChapter = LevelManager.Instance.currentChapter;
            _slider.value = (float)curChapter.chapterNum / curChapter.maxChapterInLevel;
        }
    }
}