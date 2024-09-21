using System;
using UnityEngine;

namespace _knockBalls.Scripts.Bullet
{
    public class BulletCollision : MonoBehaviour
    {
        private BulletController _bullet;

        private bool _destroy;
        
        private void Start()
        {
            _bullet = GetComponent<BulletController>();
        }

        private void CallDestroyMethod()
        {
            _destroy = false;   
            _bullet.Destroy();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag($"Plane") && !_destroy) 
            {
                _destroy = true;
                Invoke("CallDestroyMethod", .5f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag($"Wall") && !_destroy)
            {
                _destroy = true;
                Invoke("CallDestroyMethod", .5f);
            }
        }
    }
}