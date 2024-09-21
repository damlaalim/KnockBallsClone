using System;
using System.Collections.Generic;
using _knockBalls.Scripts.CanvasSystem;
using _knockBalls.Scripts.Data;
using UnityEngine;

namespace _knockBalls.Scripts.Level
{
    public class LevelManager : MonoBehaviour
    {
        public Action ChapterUpdate;
        
        public static LevelManager Instance { get; private set; } 
        
        public List<LevelController> levels;
        public ChapterController currentChapter;

        public int LevelNumber
        {
            get => PlayerPrefs.GetInt("level", 0);
            set => PlayerPrefs.SetInt("level", LevelNumber + 1 >= levels.Count ? 0 : value);
        }

        private LevelController _currentLevel;
        
        private void Awake()
        {
            Instance ??= this;
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
            Save();
            CanvasManager.Instance.Open(CanvasType.LevelSuccess);
        }
    }
 }