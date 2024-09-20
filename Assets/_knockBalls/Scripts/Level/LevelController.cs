using System.Collections.Generic;
using UnityEngine;

namespace _knockBalls.Scripts.Level
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private List<ChapterController> _chapterList;

        private int _currentChapterNum;
        private ChapterController _currentChapterObject;
        
        public void Initialize()
        {
            NextChapter();
        }

        public void NextChapter()
        {
            DestroyChapter();
            
            if (_currentChapterNum >= _chapterList.Count)
                LevelManager.Instance.NextLevel();
            else
            {
                LoadChapter();
            }

            _currentChapterNum++;
        }

        public void LoadChapter()
        {
            _currentChapterObject = Instantiate(_chapterList[_currentChapterNum], transform);
            _currentChapterObject.Initialize(this);
        }

        public void DestroyChapter()
        {
            if (_currentChapterObject)
                Destroy(_currentChapterObject.gameObject);
        }
    }
}