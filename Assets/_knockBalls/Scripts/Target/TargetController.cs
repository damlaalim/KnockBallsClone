using System.Collections;
using UnityEngine;

namespace _knockBalls.Scripts.Target
{
    public class TargetController : MonoBehaviour
    {
        [SerializeField] private bool _isGroup;
        [SerializeField] private TargetGroup _targetGroup;
        [SerializeField] private float _destroyTime;

        private bool _isDestroy;

        public void Destroy()
        {
            if (_isDestroy) return;
            _isDestroy = true;

            if (_isGroup && _targetGroup)
                _targetGroup.TargetDestroyed?.Invoke();
            
            StartCoroutine(Destroy_Routine());
        }

        private IEnumerator Destroy_Routine()
        {
            var init = 0f;
            var initScale = transform.localScale;
            
            while (init <= _destroyTime)
            {
                var normalized = init / _destroyTime;
                transform.localScale = Vector3.Lerp(initScale, Vector3.zero, normalized);
                
                init += Time.deltaTime;
                yield return 0;
            }

            transform.localScale = Vector3.zero;
        }
    }
}