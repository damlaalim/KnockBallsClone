using System.Collections;
using _knockBalls.Scripts.Level;
using _knockBalls.Scripts.Score;
using _knockBalls.Scripts.Sound;
using UnityEngine;
using AudioType = _knockBalls.Scripts.Data.AudioType;

namespace _knockBalls.Scripts.Target
{
    public class TargetController : MonoBehaviour
    {
        public bool isShoot;

        [SerializeField] private AudioType _hitAudio;
        [SerializeField] private int _puan;
        [SerializeField] private float _destroyTime;
        [SerializeField] protected Rigidbody rb;
        private ChapterController _chapter;
        
        private bool _isDestroy;

        public void Initialize(ChapterController chapter)
        {
            _chapter = chapter;
        }
        
        public virtual void Destroy()
        {
            if (_isDestroy) return;

            ScoreManager.Instance.IncreaseScore(_puan);
            _isDestroy = isShoot = true;
            
            if (_chapter.TargetFired is not null)
                _chapter.TargetFired.Invoke();

            StartCoroutine(Destroy_Routine());
        }

        private IEnumerator Destroy_Routine()
        {
            var elapsed = 0f;
            var initScale = transform.localScale;
            
            while (elapsed <= _destroyTime)
            {
                var normalized = elapsed / _destroyTime;
                transform.localScale = Vector3.Lerp(initScale, Vector3.zero, normalized);
                
                elapsed += Time.deltaTime;
                yield return 0;
            }

            transform.localScale = Vector3.zero;
        }

        public void Explode(float power, Vector3 explosionPos, float radius, float upForce)
        {
            rb.AddExplosionForce(power, explosionPos, radius, upForce, ForceMode.Impulse);
        }

        public void PlayHitSound()
        {
            SoundManager.Instance.PlayEffect(_hitAudio);
        }
    }
}