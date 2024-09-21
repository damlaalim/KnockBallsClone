using System;
using System.Collections;
using UnityEngine;

namespace _knockBalls.Scripts.Bullet
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float _fireSpeed, _destroyTime;

        private BulletManager _bulletManager;
        private Rigidbody _rb;
        private BulletCollision _collision;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _collision = GetComponent<BulletCollision>();
        }

        public void Initialize(Vector3 initPosition, BulletManager bulletManager)
        {
            transform.position = initPosition;
            _bulletManager = bulletManager;

            transform.localScale = Vector3.one;
            _rb.useGravity = true;
        }

        public void Destroy()
        {
            StartCoroutine(Destroy_Routine());
        }
        
        private IEnumerator Destroy_Routine()
        {
            var elapsed = 0f;
            Vector3 initPos = Vector3.one, endPos = Vector3.zero;
            
            while (elapsed <= _destroyTime)
            {
                var normalized = elapsed / _destroyTime;
                transform.localScale = Vector3.Lerp(initPos, endPos, normalized);    
                
                elapsed += Time.deltaTime;
                yield return 0;
            }
            
            transform.localScale = Vector3.zero;  
            _bulletManager.SetBullet(gameObject);
            _collision.destroy = false;
            _rb.useGravity = false;
            _rb.velocity = Vector3.zero;
        }
        
        public void Move(Vector3 targetPos)
        {
            var direction = (targetPos - transform.position).normalized; 
            _rb.velocity = direction * _fireSpeed;
        }
    }
}