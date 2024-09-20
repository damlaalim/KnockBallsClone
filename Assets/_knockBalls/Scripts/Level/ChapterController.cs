using System;
using System.Collections.Generic;
using System.Linq;
using _knockBalls.Scripts.Target;
using UnityEngine;

namespace _knockBalls.Scripts.Level
{
    public class ChapterController : MonoBehaviour
    {
        // TODO: mermi sayısı kontrol edilecek
        // TODO: yaratılmış mermiler silinecek 

        public Action TargetFired;

        [SerializeField] private List<TargetController> _targetList;
        [SerializeField] private Animator _anim;
        [SerializeField] private int _bulletMaxCount;

        private LevelController _level;
        private int _usedBulletCount;

        public void Initialize(LevelController level)
        {
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
                _level.ClearChapters();
                return false;
            }

            return true;
        }
    }
}