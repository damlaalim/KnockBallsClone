using System;
using UnityEngine;

namespace _knockBalls.Scripts.Bullet
{
    public class BulletCollision : MonoBehaviour
    {
        private BulletController _bullet;
        
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
            if (other.transform.CompareTag($"Plane"))
                Invoke("CallDestroyMethod", 2f);
        }
    }
}