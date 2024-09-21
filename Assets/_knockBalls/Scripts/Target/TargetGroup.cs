using System;
using System.Collections.Generic;
using UnityEngine;

namespace _knockBalls.Scripts.Target
{
    public class TargetGroup : MonoBehaviour
    {
        public Action TargetDestroyed;
        
        [SerializeField] private List<TargetController> _targetList;
        
        private void Start()
        {
            TargetDestroyed += TargetGroupDestroy;
        }

        private void TargetGroupDestroy()
        {
            TargetDestroyed -= TargetGroupDestroy;
            
            foreach (var target in _targetList)
            {
                target.Destroy();
            }
        }
    }
}