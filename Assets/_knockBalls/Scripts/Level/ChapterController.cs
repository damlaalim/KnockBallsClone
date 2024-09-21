using System;
using System.Collections.Generic;
using System.Linq;
using _knockBalls.Scripts.Bullet;
using _knockBalls.Scripts.CanvasSystem;
using _knockBalls.Scripts.Target;
using UnityEngine;

namespace _knockBalls.Scripts.Level
{
    public class ChapterController : MonoBehaviour
    {
        public Action TargetFired;
        public int chapterNum, maxChapterInLevel;

        public int RemainingNumberCount => _bulletMaxCount - _usedBulletCount;  

        [SerializeField] private List<TargetController> _targetList;
        [SerializeField] private Animator _anim;
        [SerializeField] private int _bulletMaxCount;

        private LevelController _level;
        private int _usedBulletCount;

        public void Initialize(LevelController level)
        {
            BulletManager.Instance.StartChapter(_bulletMaxCount);
            InGameCanvas.Instance.UpdateBulletCountTxt();
            _anim.CrossFade("Open", 0f);
            TargetFired += AllTargetFiredControl;
            _level = level;

            foreach (var target in _targetList)
            {
                target.Initialize(this);
            }
        }

        private void AllTargetFiredControl()
        {
            if (_targetList.Any(target => !target.isShoot))
            {
                return;
            }
            
            LevelManager.Instance.StopFinishFailChapter();
            
            _anim.CrossFade("Close", 0f);

            Invoke(nameof(CallNextChapter), 1f);
        }

        private void CallNextChapter()
        {
            _level.NextChapter();
        }

        public bool CanShoot()
        {
            _usedBulletCount++;

            if (_usedBulletCount > _bulletMaxCount)
            {
                LevelManager.Instance.FinishTheFailChapter();
                // _level.ClearChapters();
            }

            return _usedBulletCount <= _bulletMaxCount;
        }
    }
}