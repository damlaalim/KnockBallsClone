using System.Collections;
using UnityEngine;

namespace _knockBalls.Scripts.Target
{
    public class TargetController : MonoBehaviour
    {
        [SerializeField] private float _destroyTime;
        [SerializeField] protected Rigidbody rb;
        
        private bool _isDestroy;

        public virtual void Destroy()
        {
            if (_isDestroy) return;
            _isDestroy = true;

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
    }
}