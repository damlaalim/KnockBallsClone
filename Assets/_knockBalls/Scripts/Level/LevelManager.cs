using System;
using System.Collections;
using System.Collections.Generic;
using _knockBalls.Scripts.CanvasSystem;
using _knockBalls.Scripts.Data;
using _knockBalls.Scripts.Score;
using UnityEngine;

namespace _knockBalls.Scripts.Level
{
    public class LevelManager : MonoBehaviour
    {
        public Action ChapterUpdate;
        
        public static LevelManager Instance { get; private set; } 
        
        public List<LevelController> levels;
        public ChapterController currentChapter;

        [SerializeField] private float _failChapterFinishDelay;
        [SerializeField] private Color _fogColor, _renderFogColor;
        [SerializeField] private Material _fogMat, _skyBoxMat;

        private Coroutine _finishFailRoutine;
        
        public int LevelNumber
        {
            get => PlayerPrefs.GetInt("level", 0);
            set => PlayerPrefs.SetInt("level", LevelNumber + 1 >= levels.Count ? 0 : value);
        }

        public int PreLevel
        {
            get
            {
                if (PlayerPrefs.GetInt("level") - 1 >= 0)
                    return 1;
                else
                    return PlayerPrefs.GetInt("level") - 1;
            }
        }

        private LevelController _currentLevel;
        
        private void Awake()
        {
            Instance ??= this;
        }

        private void Start()
        {
            _fogMat.color = _fogColor;
            RenderSettings.skybox = _skyBoxMat;
            RenderSettings.fogColor = _renderFogColor;
        }

        public void StartGame()
        {
            Load();
        }

        private void Save()
        {
            LevelNumber += 1;
        }

        public void Load()
        {
            DestroyLevel();

            _currentLevel = Instantiate(levels[LevelNumber]);
            _currentLevel.Initialize();
        }

        public void DestroyLevel()
        {
            if (_currentLevel && _currentLevel.gameObject)
                Destroy(_currentLevel.gameObject);
        }

        public void NextLevel()
        {
            ScoreManager.Instance.FinishLevel();
            CanvasManager.Instance.Open(CanvasType.LevelSuccess);
            Save();
        }
        
        public void FinishTheFailChapter()
        {
            _finishFailRoutine = StartCoroutine(FinishTheFailChapter_Routine());
        }

        public void StopFinishFailChapter()
        {
            if (_finishFailRoutine is not null)
                StopCoroutine(_finishFailRoutine);
            
            InGameCanvas.Instance.ShowLevelTimeText(false);
            InGameCanvas.Instance.UpdateMaskImageScale(InGameCanvas.Instance.maskMaxScale * Vector3.one);
        }

        private IEnumerator FinishTheFailChapter_Routine()
        {
            var elapsed = 0f;
            var elapsedReverse = _failChapterFinishDelay;
            var inGame = InGameCanvas.Instance;

            inGame.ShowLevelTimeText(true);
            inGame.UpdateMaskImageScale(inGame.maskMaxScale * Vector3.one);
            
            while (elapsed <= _failChapterFinishDelay)
            {
                var normalized = elapsed / _failChapterFinishDelay;
                
                inGame.UpdateMaskImageScale(Vector3.Lerp(Vector3.one * inGame.maskMaxScale, Vector3.zero, normalized));
                inGame.UpdateLevelTimeText(elapsedReverse.ToString("F1"));
                
                elapsed += Time.deltaTime;
                elapsedReverse -= Time.deltaTime;
                
                yield return 0;
            }
            
            _currentLevel.ClearChapters();
        }
    }
 }