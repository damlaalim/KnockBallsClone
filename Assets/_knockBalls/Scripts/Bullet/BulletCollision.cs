using System;
using UnityEngine;

namespace _knockBalls.Scripts.Bullet
{
    public class BulletCollision : MonoBehaviour
    {
        private BulletController _bullet;

        public bool destroy;
        
        private void Start()
        {
            _bullet = GetComponent<BulletController>();
        }

        private void CallDestroyMethod()
        {
            _bullet.Destroy();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag($"Plane") && !destroy) 
            {
                destroy = true;
                Invoke("CallDestroyMethod", .5f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag($"Wall") && !destroy)
            {
                destroy = true;
                Invoke("CallDestroyMethod", .5f);
            }
        }
    }
}